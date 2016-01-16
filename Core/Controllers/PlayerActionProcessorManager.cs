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

        public void Process(PlayerChoice playerChoice)
        {
            switch (playerChoice.PlayerTurn)
            {
                case PlayerTurn.Take3DifferentGems:
                    new Take3DifferentGemsProcessor(_gameData, _playerData).Process(playerChoice.Parameters as Take3DifferentGemsParameters);
                    break;
                case PlayerTurn.BuyCard:
                    new BuyCardProcessor(_gameData, _playerData).Process(playerChoice.Parameters as BuyCardParameters);
                    break;
                case PlayerTurn.Take2TheSameGems:
                    new Take2TheSameGemsProcessor(_gameData, _playerData).Process(playerChoice.Parameters as Take2TheSameGemsParameters);
                    break;
                case PlayerTurn.BookCardAndTake1Gold:
                    new BookCardAndTake1GoldProcessor(_gameData, _playerData).Process(playerChoice.Parameters as BookCardAndTake1GoldParameters);
                    break;
                case PlayerTurn.BuyCustomer:
                    new TakeCustomerProcessor(_gameData, _playerData).Process(playerChoice.Parameters as TakeCustomerParameters);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}