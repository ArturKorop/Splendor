using System;
using Core.Controllers;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.PlayerChoiceProcessors
{
    public class BuyCardProcessor : PlayerActionProcessorBase<BuyCardParameters>
    {
        public BuyCardProcessor(GameData gameData, PlayerData playerData) : base(gameData, playerData)
        {
        }

        protected override bool CanDoPlayerAction(BuyCardParameters parameters)
        {
            throw new NotImplementedException();
        }

        protected override void DoPlayerAction(BuyCardParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}