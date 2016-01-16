using Core.Common;
using Core.Controllers;
using Core.Dto;
using Core.PlayerChoiceParameters;

namespace Core.Player
{
    public class DummyPlayerConnection : IPlayerConnection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerChoice DoTurn(GameDto getGameDto)
        {
            return new PlayerChoice
            {
                PlayerTurn = PlayerTurn.Take3DifferentGems,
                Parameters = new Take3DifferentGemsParameters
                {
                    Gems = new [] {Gem.Blue, Gem.Green, Gem.White}
                }
            };
        }
    }
}