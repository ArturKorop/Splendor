using System;
using System.Linq;
using Core.Common;
using Core.Entities;

namespace Core.Extensions
{
    public static class PriceExtensions
    {
        public static bool IsCanBuyCard(this Price price, PlayerData player)
        {
            var additionalGold = 0;
            foreach (var gem in price.Gems)
            {
                var requiredGems = gem.Value;
                var playerGemsCount = player.GemHolder.Gems[gem.Key] + player.BoughtCards.Count(x => x.GemProduct == gem.Key);
                var difference = playerGemsCount - requiredGems;

                if (difference > 0)
                {
                    additionalGold += difference;
                }
            }

            return player.GemHolder.Gems[Gem.Gold] >= additionalGold;
        }

        public static void BuyCard(this Price priceDto, PlayerData player)
        {
            var additionalGold = 0;
            foreach (var gem in priceDto.Gems)
            {
                var requiredGems = gem.Value;
                var playerGemsFromCardsCount = player.BoughtCards.Count(x => x.GemProduct == gem.Key);
                var requiredGemsFromRepository = Math.Min(requiredGems - playerGemsFromCardsCount, 0);

                if (player.GemHolder.Gems[gem.Key] < requiredGemsFromRepository)
                {
                    additionalGold += requiredGemsFromRepository - player.GemHolder.Gems[gem.Key];
                }
            }

            if (additionalGold > player.GemHolder.Gems[Gem.Gold])
            {
                throw new InvalidOperationException("Can't buy card");
            }

            player.GemHolder.Gems[Gem.Gold] -= additionalGold;
        }
    }
}