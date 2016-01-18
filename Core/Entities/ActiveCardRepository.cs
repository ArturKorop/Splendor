using System;
using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Entities
{
    public class ActiveCardRepository
    {
        public ActiveCardRepository()
        {
            Cards1Level = new List<Card>();
            Cards2Level = new List<Card>();
            Cards3Level = new List<Card>();
        }

        public ActiveCardRepository(CardRepositoryDto dto)
        {
            Cards1Level = dto.Cards1Level.Select(x => new Card(x)).ToList();
            Cards2Level = dto.Cards2Level.Select(x => new Card(x)).ToList();
            Cards3Level = dto.Cards3Level.Select(x => new Card(x)).ToList();
        }

        public ActiveCardRepository(List<Card> cards1Level, List<Card> cards2Level, List<Card> cards3Level)
        {
            Cards1Level = cards1Level;
            Cards2Level = cards2Level;
            Cards3Level = cards3Level;
        }

        public List<Card> Cards1Level { get; }
        public List<Card> Cards2Level { get; }
        public List<Card> Cards3Level { get; }

        public IEnumerable<Card> AllCards => Cards1Level.Union(Cards2Level).Union(Cards3Level);
    }
}