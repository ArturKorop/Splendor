using Core.Controllers;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.PlayerChoiceProcessors
{
    public class Take2TheSameGemsProcessor : PlayerActionProcessorBase<Take2TheSameGemsParameters>
    {
        public Take2TheSameGemsProcessor(GameData gameData, PlayerData playerData) : base(gameData, playerData)
        {
        }

        protected override bool CanDoPlayerAction(Take2TheSameGemsParameters parameters)
        {
            var selectedGemCount = GameData.GemHolder.Gems[parameters.Gem];

            return selectedGemCount == GameData.Config.StartGemsCount;
        }

        protected override void DoPlayerAction(Take2TheSameGemsParameters parameters)
        {
            GameData.GemHolder.TransferTo(PlayerData.GemHolder, parameters.Gem, 2);
        }
    }
}