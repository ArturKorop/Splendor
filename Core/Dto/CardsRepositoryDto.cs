using System.Collections.Generic;

namespace Core.Dto
{
    public class CardsRepositoryDto
    {
        public List<CardDto> Cards1Level { get; set; }
        public List<CardDto> Cards2Level { get; set; }
        public List<CardDto> Cards3Level { get; set; }

        public CardsRepositoryDto()
        {
            Cards1Level = new List<CardDto>();
            Cards2Level = new List<CardDto>();
            Cards3Level = new List<CardDto>();
        }
    }
}