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

        public PlayerActionProcessorManager(GameData gameData, PlayerData playerData)
        {
            _gameData = gameData;
            _playerData = playerData;
        }

        public void ProcessMainAction(PlayerMainAction playerMainAction)
        {
            switch (playerMainAction.MainAction)
            {
                case MainAction.Take3DifferentGems:
                    new Take3DifferentGemsProcessor(_gameData, _playerData).Process(playerMainAction.Parameters as Take3DifferentGemsParameters);
                    break;
                case MainAction.BuyCard:
                    new BuyCardProcessor(_gameData, _playerData).Process(playerMainAction.Parameters as BuyCardParameters);
                    break;
                case MainAction.Take2TheSameGems:
                    new Take2TheSameGemsProcessor(_gameData, _playerData).Process(playerMainAction.Parameters as Take2TheSameGemsParameters);
                    break;
                case MainAction.BookCardAndTake1Gold:
                    new BookCardAndTake1GoldProcessor(_gameData, _playerData).Process(playerMainAction.Parameters as BookCardAndTake1GoldParameters);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public void ProcessTakeCustomerAction(Customer parameters)
        {
            new TakeCustomerProcessor(_gameData, _playerData).Process(parameters);
        }
    }
}