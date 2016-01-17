using Core.Entities;

namespace Core.Controllers
{
    public class GameController
    {
        private readonly GameData _gameData;

        public GameController(GameData data)
        {
            _gameData = data;
        }

        public void Start()
        {
            while (!_gameData.IsGameFinished)
            {
                var player = _gameData.PlayersRoundManager.GetNext();
                var playerStatus = _gameData.GameRoundManager.GetPlayerRoundStatus(player.PlayerData.Id);
                playerStatus.Clear();

                var processor = new PlayerActionProcessorManager(_gameData, player.PlayerData);

                while (!playerStatus.IsMainActionDone)
                {
                    PlayerMainAction playerAction = player.Connection.DoMainAction(_gameData.GetGameDto());

                    processor.ProcessMainAction(playerAction);
                }

                while (!playerStatus.IsCustomerTaken && player.PlayerData.CanTakeCustomer(_gameData))
                {
                    Customer selectedCustomer = player.Connection.TakeCustomer(_gameData);

                    processor.ProcessTakeCustomerAction(selectedCustomer);
                }

                playerStatus.IsActionFinished = true;
            }
        }
    }
}