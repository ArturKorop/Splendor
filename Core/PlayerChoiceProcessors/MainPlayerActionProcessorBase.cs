using Core.Controllers;
using Core.Entities;

namespace Core.PlayerChoiceProcessors
{
    public abstract class MainPlayerActionProcessorBase<T> : PlayerActionProcessorBase<T>
    {
        protected MainPlayerActionProcessorBase(GameData gameData, PlayerData playerData) : base(gameData, playerData)
        {
        }

        protected override bool CanDoPlayerAction(T parameters)
        {
            var playerStatus = GameData.GameRoundManager.GetPlayerRoundStatus(PlayerData.Id);

            return !playerStatus.IsActionFinished && CanDoMainPlayerAction(parameters);
        }

        protected abstract bool CanDoMainPlayerAction(T parameters);
    }
}