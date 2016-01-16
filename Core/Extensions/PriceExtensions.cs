//using System;
//using System.Linq;
//using Core.Dto;

//namespace Core
//{
//    public static class PriceExtensions
//    {
//        public static bool IsCanBuyCard(this Price priceDto, PlayerData player)
//        {
//            var additionalGold = 0;
//            foreach (var gem in priceDto.GemHolder)
//            {
//                var requiredGems = gem.Value;
//                var playerGemsCount = player.GemHolder.Repository[gem.Key] + player.BoughtCards.Count(x => x.GemProduct == gem.Key);
//                var difference = playerGemsCount - requiredGems;

//                if(difference > 0)
//                {
//                    additionalGold += difference;
//                }
//            }

//            return player.GemHolder.Repository[Gem.Gold] >= additionalGold;
//        }

//        public static void BuyCard(this Price priceDto, PlayerData player)
//        {
//            var additionalGold = 0;
//            foreach (var gem in priceDto.GemHolder)
//            {
//                var requiredGems = gem.Value;
//                var playerGemsFromCardsCount = player.BoughtCards.Count(x => x.GemProduct == gem.Key);
//                var requiredGemsFromRepository = Math.Min(requiredGems - playerGemsFromCardsCount, 0);

//                if (player.GemHolder.Repository[gem.Key] < requiredGemsFromRepository)
//                {
//                    additionalGold += requiredGemsFromRepository - player.GemHolder.Repository[gem.Key];
//                }
//            }

//            if(additionalGold > player.GemHolder.Repository[Gem.Gold])
//            {
//                throw  new InvalidOperationException("Can't buy card");
//            }

//            player.GemHolder.Repository[Gem.Gold] -= additionalGold;
//        }
//    }
//}