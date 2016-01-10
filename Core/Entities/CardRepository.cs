using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Entities
{
    public class CardRepository
    {
        public CardRepository()
        {
            Cards1Level = new List<Card>();
            Cards2Level = new List<Card>();
            Cards3Level = new List<Card>();
        }

        public CardRepository(CardRepositoryDto dto)
        {
            Cards1Level = dto.Cards1Level.Select(x => new Card(x)).ToList();
            Cards2Level = dto.Cards2Level.Select(x => new Card(x)).ToList();
            Cards3Level = dto.Cards3Level.Select(x => new Card(x)).ToList();
        }

        public List<Card> Cards1Level { get; }
        public List<Card> Cards2Level { get; }
        public List<Card> Cards3Level { get; }
    }
}