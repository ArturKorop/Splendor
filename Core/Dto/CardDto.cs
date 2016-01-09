using Core.Common;

namespace Core.Dto
{
    public class CardDto
    {
        public PriceDto PriceDto { get; set; }

        public Gem GemProduct { get; set; }

        public int Level { get; set; }

        public int Vp { get; set; }

        public int Id { get; set; }
    }
}