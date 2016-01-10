using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Entities
{
    public class Player
    {
        public Player(int id)
        {
            Id = id;
            Gems = new GemRepository();
            BookedCards = new List<Card>();
            BoughtCards = new List<Card>();
            Customers = new List<Customer>();
        }

        public Player(PlayerDto dto)
        {
            Id = dto.Id;
            Gems = new GemRepository(dto.Gems);
            BoughtCards = dto.BoughtCards.Select(x => new Card(x)).ToList();
            BookedCards = dto.BookedCards.Select(x => new Card(x)).ToList();
            Customers = dto.Customers.Select(x=>new Customer(x)).ToList();
        }

        public int Id { get; set; }

        public GemRepository Gems { get; private set; }

        public List<Card> BoughtCards { get; private set; } 

        public List<Card> BookedCards { get; private set; }

        public List<Customer> Customers { get; private set; } 

        public int Vp
        {
            get { return Customers.Sum(x => x.Vp) + BoughtCards.Sum(x => x.Vp); }
        }
    }
}