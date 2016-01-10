using Core.Common;
using Core.Dto;

namespace Core.Entities
{
    public class Card
    {
        public Price Price { get; }

        public Gem GemProduct { get; }

        public int Level { get; }

        public int Vp { get; }

        public int Id { get; }

        public Card(Price price, Gem product, int level, int vp, int id)
        {
            Price = price;
            GemProduct = product;
            Level = level;
            Vp = vp;
            Id = id;
        }

        public Card(CardDto dto)
        {
            Price = new Price(dto.Price);
            GemProduct = dto.GemProduct;
            Level = dto.Level;
            Vp = dto.Vp;
            Id = dto.Id;
        }
    }
}
