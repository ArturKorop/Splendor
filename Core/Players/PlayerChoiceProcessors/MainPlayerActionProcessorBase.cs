using Core.Entities;

namespace Core.Players.PlayerChoiceProcessors
{
    public abstract class MainPlayerActionProcessorBase<T> : PlayerActionProcessorBase<T>
    {
        protected MainPlayerActionProcessorBase(GameData gameData, PlayerData playerData, PlayerRoundStatus playerRoundStatus) : base(gameData, playerData, playerRoundStatus)
        {
        }

        protected override bool CanDoPlayerAction(T parameters)
        {
            return !PlayerRoundStatus.IsActionFinished && CanDoMainPlayerAction(parameters);
        }

        protected override void UpdatePlayerStatus()
        {
            PlayerRoundStatus.IsMainActionDone = true;
        }

        protected abstract bool CanDoMainPlayerAction(T parameters);
    }
}