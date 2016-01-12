using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Controllers;
using Core.Dto;
using Core.Entities;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class SerializerTests
    {
        [Test]
        public void SerializeDeserialize_GameDto_Correct()
        {
            var game = new GameController(2) ;
            var gameDto = game.GetGameDto();
            gameDto.Gems.Repository = new List<GemCountDto> {new GemCountDto(Gem.Green, 5)};

            var serializeStr = SerializeHelper.Serialize(gameDto);
            var result = SerializeHelper.Deserialize<GameDto>(serializeStr);

            Assert.AreEqual(5, result.Gems.Repository.Single(x => x.Gem == Gem.Green).Count);
        }
    }
}