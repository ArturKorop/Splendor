using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Core.Dto;

namespace Core.Controllers
{
    public class PlayerController
    {
        public PlayerController(int id)
        {
            Id = id;
            Gems = new GemRepositoryController();
            BookedCards = new List<CardDto>();

        }

        public PlayerController(PlayerDto dto)
        {
            Id = dto.Id;
            Gems = new GemRepositoryController(dto.Gems);
            BoughtCards = dto.BoughtCards;
            BookedCards = dto.BookedCards;
            Customers = dto.Customers;
        }

        public int Id { get; set; }

        public GemRepositoryController Gems { get; private set; }

        public List<CardDto> BoughtCards { get; private set; } 

        public List<CardDto> BookedCards { get; private set; }

        public List<CustomerDto> Customers { get; private set; } 

        public int Vp
        {
            get { return Customers.Sum(x => x.Vp) + BoughtCards.Sum(x => x.Vp); }
        }
    }
}