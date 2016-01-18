using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Entities
{
    public class InactiveCardRepository
    {
        public InactiveCardRepository()
        {
            Cards1Level = new Queue<Card>();
            Cards2Level = new Queue<Card>();
            Cards3Level = new Queue<Card>();
        }

        public InactiveCardRepository(CardRepositoryDto dto)
        {
            Cards1Level = new Queue<Card>(dto.Cards1Level.Select(x => new Card(x)));
            Cards2Level = new Queue<Card>(dto.Cards2Level.Select(x => new Card(x)));
            Cards3Level = new Queue<Card>(dto.Cards3Level.Select(x => new Card(x)));
        }

        public InactiveCardRepository(IEnumerable<Card> cards1Level, IEnumerable<Card> cards2Level,
            IEnumerable<Card> cards3Level)
        {
            Cards1Level = new Queue<Card>(cards1Level);
            Cards2Level = new Queue<Card>(cards2Level);
            Cards3Level = new Queue<Card>(cards3Level);
        }

        public Queue<Card> Cards1Level { get; }
        public Queue<Card> Cards2Level { get; }
        public Queue<Card> Cards3Level { get; }
    }
}