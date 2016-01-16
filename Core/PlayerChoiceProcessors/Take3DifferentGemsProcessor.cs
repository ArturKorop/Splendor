using System.Linq;
using Core.Controllers;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.PlayerChoiceProcessors
{
    public class Take3DifferentGemsProcessor : MainPlayerActionProcessorBase<Take3DifferentGemsParameters>
    {
        public Take3DifferentGemsProcessor(GameData gameData, PlayerData playerData) : base(gameData, playerData)
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