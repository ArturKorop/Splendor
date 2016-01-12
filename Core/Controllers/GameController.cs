using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;
using Core.Entities;

namespace Core.Controllers
{
    public class GameController
    {
        public GameController(int playerCount)
        {
            Players = new List<Player>();
            CardHolder = new CardHolders();
            Gems = new GemRepository();
            Customers = new List<Customer>();
            var temp = GameStorage.Instance;
        }

        public GameController(GameDto dto)
        {
            Players = dto.Players.Select(x => new Player(x)).ToList();
            CardHolder = new CardHolders(dto.CardHolder);
            Gems = new GemRepository(dto.Gems);
            Customers = dto.Customers.Select(x => new Customer(x)).ToList();
        }

        public List<Player> Players { get; }

        public CardHolders CardHolder { get; }

        public GemRepository Gems { get; }

        public List<Customer> Customers { get; }
    }
}