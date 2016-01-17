using System.Collections.Generic;
using System.Linq;
using Core.Controllers;
using Core.Dto;
using Core.Extensions;

namespace Core.Entities
{
    public class PlayerData
    {
        public PlayerData(int id)
        {
            Id = id;
            GemHolder = new GemHolder(0,0);
            BookedCards = new List<Card>();
            BoughtCards = new List<Card>();
            Customers = new List<Customer>();
        }

        public PlayerData(PlayerDto dto)
        {
            Id = dto.Id;
            GemHolder = new GemHolder(dto.Gems);
            BoughtCards = dto.BoughtCards.Select(x => new Card(x)).ToList();
            BookedCards = dto.BookedCards.Select(x => new Card(x)).ToList();
            Customers = dto.Customers.Select(x=>new Customer(x)).ToList();
        }

        public int Id { get; set; }

        public GemHolder GemHolder { get; private set; }

        public List<Card> BoughtCards { get; private set; } 

        public List<Card> BookedCards { get; private set; }

        public List<Customer> Customers { get; private set; } 

        public int Vp
        {
            get { return Customers.Sum(x => x.Vp) + BoughtCards.Sum(x => x.Vp); }
        }

        public bool CanTakeCustomer(GameData gameData)
        {
            return gameData.Customers.Any(x => GemHolder.CanTakeCustomer(x));
        }
    }
}