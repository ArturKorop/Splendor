using System.Collections.Generic;
using System.Linq;
using Core.Dto;

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

        public GemHolder GemHolder { get; }

        public List<Card> BoughtCards { get; } 

        public List<Card> BookedCards { get; }

        public List<Customer> Customers { get; } 

        public int Vp
        {
            get { return Customers.Sum(x => x.Vp) + BoughtCards.Sum(x => x.Vp); }
        }

        public bool CanTakeCustomer(GameData gameData)
        {
            return gameData.Customers.Any(IsHaveEnoughCardsForCustomer);
        }

        private bool IsHaveEnoughCardsForCustomer(Customer customer)
        {
            foreach (var gem in customer.Price.Gems)
            {
                var playerGems = BoughtCards.Count(x => x.GemProduct == gem.Key);
                if(playerGems < gem.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}