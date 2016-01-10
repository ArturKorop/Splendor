using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Controllers
{
    public class CardRepositoryController
    {
        public CardRepositoryController()
        {
            Cards1Level = new List<CardController>();
            Cards2Level = new List<CardController>();
            Cards3Level = new List<CardController>();
        }

        public CardRepositoryController(CardRepositoryDto dto)
        {
            Cards1Level = dto.Cards1Level.Select(x => new CardController(x)).ToList();
            Cards2Level = dto.Cards2Level.Select(x => new CardController(x)).ToList();
            Cards3Level = dto.Cards3Level.Select(x => new CardController(x)).ToList();
        }

        public List<CardController> Cards1Level { get; }
        public List<CardController> Cards2Level { get; }
        public List<CardController> Cards3Level { get; }
    }
}