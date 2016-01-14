using System;
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

                var playerShouldDoTurn = true;
                while (playerShouldDoTurn)
                {
                    PlayerChoice result = player.Connection.DoTurn(_gameData.GetGameDto());

                    ProcessPlayerTurn(result);

                    playerShouldDoTurn = result.PlayerTurn != PlayerTurn.Finish;
                }
            }
        }

        private void ProcessPlayerTurn(PlayerChoice result)
        {
            IProcessPlayerTurn processor;
            switch (result.PlayerTurn)
            {
                case PlayerTurn.Take3DifferentGems:
                    processor = new Take3DifferentGemsProcessor(_gameData);
                    break;
                case PlayerTurn.BuyCard:
                    processor = new BuyCardProcessor(_gameData);
                    break;
                case PlayerTurn.Take2TheSameGems:
                    processor = new Take2TheSameGemsProcessor(_gameData);
                    break;
                case PlayerTurn.BookCardAndTake1Gold:
                    processor = new BookCardAndTake1GoldProcessor(_gameData);
                    break;
                case PlayerTurn.BuyCustomer:
                    processor = new BuyCustomerProcessor(_gameData);
                    break;
                case PlayerTurn.Finish:
                    processor = new FinishProcessor(_gameData);
                    break;

                default:
                    throw new InvalidOperationException();
            }

            processor.Process(result.Parameters);
        }
    }

    public class FinishProcessor : IProcessPlayerTurn
    {
        public FinishProcessor(GameData gameData)
        {
            throw new NotImplementedException();
        }

        public void Process(object parameters)
        {
        }
    }

    public class BuyCustomerProcessor : IProcessPlayerTurn
    {
        public BuyCustomerProcessor(GameData gameData)
        {
            throw new NotImplementedException();
        }

        public void Process(object parameters)
        {
            throw new NotImplementedException();
        }
    }

    public class Take2TheSameGemsProcessor : IProcessPlayerTurn
    {
        public Take2TheSameGemsProcessor(GameData gameData)
        {
            throw new NotImplementedException();
        }

        public void Process(object parameters)
        {
            throw new NotImplementedException();
        }
    }

    public class BookCardAndTake1GoldProcessor : IProcessPlayerTurn
    {
        public BookCardAndTake1GoldProcessor(GameData gameData)
        {
            throw new NotImplementedException();
        }

        public void Process(object parameters)
        {
            throw new NotImplementedException();
        }
    }

    internal class BuyCardProcessor : IProcessPlayerTurn
    {
        public BuyCardProcessor(GameData gameData)
        {
            throw new NotImplementedException();
        }

        public void Process(object parameters)
        {
            throw new NotImplementedException();
        }
    }

    public class Take3DifferentGemsProcessor : IProcessPlayerTurn
    {
        public Take3DifferentGemsProcessor(GameData gameData)
        {
        }

        public void Process(object parameters)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProcessPlayerTurn
    {
        void Process(object parameters);
    }
}