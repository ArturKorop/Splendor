using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Controllers;
using Core.Dto;
using Core.Entities;
using Core.Players;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class SerializerTests
    {
        [Test]
        public void SerializeDeserialize_GameDto_Correct()
        {
            var game = new GameData(new List<IPlayerConnection> {new DummyPlayerConnection() {Id = 1}, new DummyPlayerConnection() {Id = 2} }) ;
            var gameDto = game.GetGameDto();
            gameDto.GemHolder.Repository = new List<GemCountDto> {new GemCountDto(Gem.Green, 5)};

            var serializeStr = SerializeHelper.Serialize(gameDto);
            var result = SerializeHelper.Deserialize<GameDto>(serializeStr);

            Assert.AreEqual(5, result.GemHolder.Repository.Single(x => x.Gem == Gem.Green).Count);
        }
    }
}