using System.Collections.Generic;

namespace Core.Dto
{
    public class CardRepositoryDto
    {
        public List<CardDto> Cards1Level { get; set; }
        public List<CardDto> Cards2Level { get; set; }
        public List<CardDto> Cards3Level { get; set; }
    }
}