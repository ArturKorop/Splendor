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
//            foreach (var gem in priceDto.Gems)
//            {
//                var requiredGems = gem.Value;
//                var playerGemsCount = player.Gems.Repository[gem.Key] + player.BoughtCards.Count(x => x.GemProduct == gem.Key);
//                var difference = playerGemsCount - requiredGems;

//                if(difference > 0)
//                {
//                    additionalGold += difference;
//                }
//            }

//            return player.Gems.Repository[Gem.Gold] >= additionalGold;
//        }

//        public static void BuyCard(this Price priceDto, PlayerData player)
//        {
//            var additionalGold = 0;
//            foreach (var gem in priceDto.Gems)
//            {
//                var requiredGems = gem.Value;
//                var playerGemsFromCardsCount = player.BoughtCards.Count(x => x.GemProduct == gem.Key);
//                var requiredGemsFromRepository = Math.Min(requiredGems - playerGemsFromCardsCount, 0);

//                if (player.Gems.Repository[gem.Key] < requiredGemsFromRepository)
//                {
//                    additionalGold += requiredGemsFromRepository - player.Gems.Repository[gem.Key];
//                }
//            }

//            if(additionalGold > player.Gems.Repository[Gem.Gold])
//            {
//                throw  new InvalidOperationException("Can't buy card");
//            }

//            player.Gems.Repository[Gem.Gold] -= additionalGold;
//        }
//    }
//}