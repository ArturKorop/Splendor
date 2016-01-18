using System;
using Core.Entities;

namespace Core.Players.PlayerChoiceProcessors
{
    public class TakeCustomerProcessor : PlayerActionProcessorBase<Customer>
    {
        public TakeCustomerProcessor(GameData gameData, PlayerData playerData, PlayerRoundStatus playerRoundStatus) : base(gameData, playerData, playerRoundStatus)
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
            PlayerRoundStatus.IsCustomerTaken = true;
        }
    }
}