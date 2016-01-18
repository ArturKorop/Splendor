using Core.Common;
using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Core.Players.PlayerChoiceParameters;

namespace Core.Players.Entities
{
    public class DummyPlayerConnection : IPlayerConnection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerMainAction DoMainAction(GameDto getGameDto)
        {
            return new PlayerMainAction
            {
                MainTurnAction = MainTurnAction.Take3DifferentGems,
                Parameters = new Take3DifferentGemsParameters
                {
                    Gems = new [] {Gem.Blue, Gem.Green, Gem.White}
                }
            };
        }

        public Customer TakeCustomer(GameData gameData)
        {
            return null;
        }
    }
}