using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Controllers
{
    public class PlayerController
    {
        public PlayerController(int id)
        {
            Id = id;
            Gems = new GemRepositoryController();
            BookedCards = new List<CardController>();
            BoughtCards = new List<CardController>();
            Customers = new List<CustomerController>();
        }

        public PlayerController(PlayerDto dto)
        {
            Id = dto.Id;
            Gems = new GemRepositoryController(dto.Gems);
            BoughtCards = dto.BoughtCards.Select(x => new CardController(x)).ToList();
            BookedCards = dto.BookedCards.Select(x => new CardController(x)).ToList();
            Customers = dto.Customers.Select(x=>new CustomerController(x)).ToList();
        }

        public int Id { get; set; }

        public GemRepositoryController Gems { get; private set; }

        public List<CardController> BoughtCards { get; private set; } 

        public List<CardController> BookedCards { get; private set; }

        public List<CustomerController> Customers { get; private set; } 

        public int Vp
        {
            get { return Customers.Sum(x => x.Vp) + BoughtCards.Sum(x => x.Vp); }
        }
    }
}