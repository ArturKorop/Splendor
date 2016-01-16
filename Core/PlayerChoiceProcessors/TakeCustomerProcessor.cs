using System;
using Core.Controllers;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.PlayerChoiceProcessors
{
    public class TakeCustomerProcessor : PlayerActionProcessorBase<TakeCustomerParameters>
    {
        public TakeCustomerProcessor(GameData gameData, PlayerData playerData) : base(gameData, playerData)
        {
        }

        protected override bool CanDoPlayerAction(TakeCustomerParameters parameters)
        {
            throw new NotImplementedException();
        }

        protected override void DoPlayerAction(TakeCustomerParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}