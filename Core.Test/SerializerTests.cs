using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class SerializerTests
    {
        [Test]
        public void SerializeDeserialize_GameDto_Correct()
        {
            var game = new GameDto
            {
                Gems = new GemRepositoryDto {Repository = new List<GemCountDto> { new GemCountDto { Gem = Gem.Green, Count = 5} }}
            };

            var serializeStr = SerializeHelper.Serialize(game);
            var result = SerializeHelper.Deserialize<GameDto>(serializeStr);

            Assert.AreEqual(5, result.Gems.Repository.Single(x=>x.Gem == Gem.Green).Count);
        }
    }
}