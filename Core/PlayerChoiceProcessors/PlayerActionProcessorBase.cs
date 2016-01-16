using Core.Controllers;
using Core.Entities;
using Core.Interfaces;

namespace Core.PlayerChoiceProcessors
{
    public abstract class PlayerActionProcessorBase<T> : IPlayerActionProcessor<T>
    {
        protected GameData GameData;

        protected PlayerData PlayerData;

        protected PlayerActionProcessorBase(GameData gameData, PlayerData playerData)
        {
            GameData = gameData;
            PlayerData = playerData;
        }

        public virtual void Process(T parameters)
        {
            if(CanDoPlayerAction(parameters))
            {
                DoPlayerAction(parameters);
            }
        }

        protected abstract bool CanDoPlayerAction(T parameters);

        protected abstract void DoPlayerAction(T parameters);
    }
}