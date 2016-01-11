using System.Collections.Generic;
using Core.Common;
using Core.Dto;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class GameStorageTests
    {
        [Test]
        public void GameStorage_Init_Successfull()
        {

            var storage = SerializeHelper.DeserializeFromFile<GameStorage>(@"E:\git\Splendor\Core\Cards.xml");

            var test = storage.Save();
            var price = new PriceDto {Gems = new List<GemCountDto> {new GemCountDto(Gem.Blue, 1)}};
            var test2 = SerializeHelper.Serialize(price);
            var priceDto = SerializeHelper.Deserialize<PriceDto>(test2);
        }
    }
}
