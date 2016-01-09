using Core.Common;
using Core.Dto;

namespace Core.Controllers
{
    public class CardController
    {
        public PriceController Price { get; }

        public Gem GemProduct { get; }

        public int Level { get; }

        public int Vp { get; }

        public int Id { get; }

        public CardController(PriceController price, Gem product, int level, int vp, int id)
        {
            Price = price;
            GemProduct = product;
            Level = level;
            Vp = vp;
            Id = id;
        }

        public CardController(CardDto dto)
        {
            Price = new PriceController(dto.PriceDto);
            GemProduct = dto.GemProduct;
            Level = dto.Level;
            Vp = dto.Vp;
            Id = dto.Id;
        }
    }
}
