using System;
using Core.Entities;
using Core.PlayerChoiceParameters;
using Core.PlayerChoiceProcessors;

namespace Core.Controllers
{
    public class PlayerActionProcessorManager
    {
        private readonly GameData _gameData;

        private readonly PlayerData _playerData;

        private readonly PlayerRoundStatus _playerRoundStatus;

        public PlayerActionProcessorManager(GameData gameData, PlayerData playerData, PlayerRoundStatus playerRoundStatus)
        {
            _gameData = gameData;
            _playerData = playerData;
            _playerRoundStatus = playerRoundStatus;
        }

        public void ProcessMainAction(PlayerMainAction playerMainAction)
        {
            switch (playerMainAction.MainTurnAction)
            {
                case MainTurnAction.Take3DifferentGems:
                    new Take3DifferentGemsProcessor(_gameData, _playerData, _playerRoundStatus).Process(playerMainAction.Parameters as Take3DifferentGemsParameters);
                    break;
                case MainTurnAction.BuyCard:
                    new BuyCardProcessor(_gameData, _playerData, _playerRoundStatus).Process(playerMainAction.Parameters as BuyCardParameters);
                    break;
                case MainTurnAction.Take2TheSameGems:
                    new Take2TheSameGemsProcessor(_gameData, _playerData, _playerRoundStatus).Process(playerMainAction.Parameters as Take2TheSameGemsParameters);
                    break;
                case MainTurnAction.BookCardAndTake1Gold:
                    new BookCardAndTake1GoldProcessor(_gameData, _playerData, _playerRoundStatus).Process(playerMainAction.Parameters as BookCardAndTake1GoldParameters);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public void ProcessTakeCustomerAction(Customer parameters)
        {
            new TakeCustomerProcessor(_gameData, _playerData, _playerRoundStatus).Process(parameters);
        }
    }
}