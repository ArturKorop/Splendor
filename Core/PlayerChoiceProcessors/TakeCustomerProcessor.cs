using System;
using Core.Controllers;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.PlayerChoiceProcessors
{
    public class TakeCustomerProcessor : PlayerActionProcessorBase<Customer>
    {
        public TakeCustomerProcessor(GameData gameData, PlayerData playerData) : base(gameData, playerData)
        {
        }

        protected override bool CanDoPlayerAction(Customer parameters)
        {
            throw new NotImplementedException();
        }

        protected override void DoPlayerAction(Customer parameters)
        {
            throw new NotImplementedException();
        }

        protected override void UpdatePlayerStatus()
        {
            GameData.GameRoundManager.PlayerDoneCustomerTakenAction(PlayerData.Id);
        }
    }
}