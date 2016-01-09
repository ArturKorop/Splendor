using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Controllers
{
    public class GameController
    {
        public GameController()
        {
            Players = new List<PlayerController>();
            CardHolder = new CardHolderController();
            Gems = new GemRepositoryController();
            Customers = new List<CustomerController>();
        }

        public GameController(GameDto dto)
        {
            Players = dto.Players.Select(x => new PlayerController(x)).ToList();
            CardHolder = new CardHolderController(dto.CardHolder);
            Gems = new GemRepositoryController(dto.Gems);
            Customers = dto.Customers.Select(x => new CustomerController(x)).ToList();
        }

        public List<PlayerController> Players { get; }

        public CardHolderController CardHolder { get; }

        public GemRepositoryController Gems { get; }

        public List<CustomerController> Customers { get; }
    }
}