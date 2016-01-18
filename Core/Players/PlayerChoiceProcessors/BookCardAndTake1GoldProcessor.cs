using System.Linq;
using Core.Common;
using Core.Entities;
using Core.Players.PlayerChoiceParameters;

namespace Core.Players.PlayerChoiceProcessors
{
    public class BookCardAndTake1GoldProcessor : MainPlayerActionProcessorBase<BookCardAndTake1GoldParameters>
    {
        public BookCardAndTake1GoldProcessor(GameData gameData, PlayerData playerData,
            PlayerRoundStatus playerRoundStatus) : base(gameData, playerData, playerRoundStatus)
        {
        }

        protected override bool CanDoMainPlayerAction(BookCardAndTake1GoldParameters parameters)
        {
            return GameData.CardHolder.ActiveCards.AllCards.Any(x => x.Id == parameters.Card.Id);
        }

        protected override void DoPlayerAction(BookCardAndTake1GoldParameters parameters)
        {
            GameData.CardHolder.BookCard(parameters.Card.Id, PlayerData);
            if (GameData.GemHolder.CanTransfer(Gem.Gold, 1))
            {
                GameData.GemHolder.TransferTo(PlayerData.GemHolder, Gem.Gold, 1);
            }
        }
    }
}