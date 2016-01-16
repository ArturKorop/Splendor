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

                var playerDoingTurn = true;
                while (playerDoingTurn)
                {
                    PlayerChoice result = player.Connection.DoTurn(_gameData.GetGameDto());

                    ProcessPlayerTurn(result, player.PlayerData);

                    playerDoingTurn = result.PlayerTurn != PlayerTurn.Finish;
                }
            }
        }   

        private void ProcessPlayerTurn(PlayerChoice playerChoice, PlayerData playerData)
        {
            var processor = new PlayerActionProcessorManager(_gameData, playerData);
            processor.Process(playerChoice);
        }
    }
}