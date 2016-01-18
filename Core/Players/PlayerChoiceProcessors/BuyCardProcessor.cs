using System;
using Core.Entities;
using Core.Players.PlayerChoiceParameters;

namespace Core.Players.PlayerChoiceProcessors
{
    public class BuyCardProcessor : MainPlayerActionProcessorBase<BuyCardParameters>
    {
        public BuyCardProcessor(GameData gameData, PlayerData playerData, PlayerRoundStatus playerRoundStatus) : base(gameData, playerData, playerRoundStatus)
        {
        }

        protected override bool CanDoMainPlayerAction(BuyCardParameters parameters)
        {
            throw new NotImplementedException();
        }

        protected override void DoPlayerAction(BuyCardParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}