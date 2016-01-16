using System;
using Core.Controllers;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.PlayerChoiceProcessors
{
    public class BookCardAndTake1GoldProcessor : PlayerActionProcessorBase<BookCardAndTake1GoldParameters>
    {
        public BookCardAndTake1GoldProcessor(GameData gameData, PlayerData playerData) : base(gameData, playerData)
        {
        }

        protected override bool CanDoPlayerAction(BookCardAndTake1GoldParameters parameters)
        {
            throw new NotImplementedException();
        }

        protected override void DoPlayerAction(BookCardAndTake1GoldParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}