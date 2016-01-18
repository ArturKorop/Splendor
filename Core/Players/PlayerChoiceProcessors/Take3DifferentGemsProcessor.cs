using System.Linq;
using Core.Entities;
using Core.Players.PlayerChoiceParameters;

namespace Core.Players.PlayerChoiceProcessors
{
    public class Take3DifferentGemsProcessor : MainPlayerActionProcessorBase<Take3DifferentGemsParameters>
    {
        public Take3DifferentGemsProcessor(GameData gameData, PlayerData playerData, PlayerRoundStatus playerRoundStatus) : base(gameData, playerData, playerRoundStatus)
        {
        }

        protected override bool CanDoMainPlayerAction(Take3DifferentGemsParameters parameters)
        {
            var gems = GameData.GemHolder;

            return parameters.Gems.All(gem => gems.Gems[gem] > 0);
        }

        protected override void DoPlayerAction(Take3DifferentGemsParameters parameters)
        {
            foreach (var gem in parameters.Gems)
            {
                GameData.GemHolder.TransferTo(PlayerData.GemHolder, gem, 1);
            }
        }
    }
}