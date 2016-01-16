using System.Linq;
using Core.Controllers;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.PlayerChoiceProcessors
{
    public class Take3DifferentGemsProcessor : PlayerActionProcessorBase<Take3DifferentGemsParameters>
    {
        public Take3DifferentGemsProcessor(GameData gameData, PlayerData playerData) : base(gameData, playerData)
        {
        }

        protected override bool CanDoPlayerAction(Take3DifferentGemsParameters take3DifferentGemsParameters)
        {
            var gems = GameData.GemHolder;

            return take3DifferentGemsParameters.Gems.All(gem => gems.Gems[gem] > 0);
        }

        protected override void DoPlayerAction(Take3DifferentGemsParameters take3DifferentGemsParameters)
        {
            foreach (var gem in take3DifferentGemsParameters.Gems)
            {
                GameData.GemHolder.TransferTo(PlayerData.GemHolder, gem, 1);
            }
        }
    }
}