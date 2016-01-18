using Core.Entities;
using Core.Interfaces;

namespace Core.PlayerChoiceProcessors
{
    public abstract class PlayerActionProcessorBase<T> : IPlayerActionProcessor<T>
    {
        protected GameData GameData;

        protected PlayerData PlayerData;

        protected PlayerRoundStatus PlayerRoundStatus;

        protected PlayerActionProcessorBase(GameData gameData, PlayerData playerData, PlayerRoundStatus playerRoundStatus)
        {
            GameData = gameData;
            PlayerData = playerData;
            PlayerRoundStatus = playerRoundStatus;
        }

        public virtual void Process(T parameters)
        {
            if(CanDoPlayerAction(parameters))
            {
                DoPlayerAction(parameters);
                UpdatePlayerStatus();
            }
        }

        protected abstract bool CanDoPlayerAction(T parameters);

        protected abstract void DoPlayerAction(T parameters);

        protected abstract void UpdatePlayerStatus();
    }
}