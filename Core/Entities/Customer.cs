using Core.Dto;

namespace Core.Entities
{
    public class Customer
    {
        public Price Price { get; }

        public int Vp { get; }

        public string Name { get; set; }

        public Customer(Price price, int vp, string name)
        {
            Price = price;
            Vp = vp;
            Name = name;
        }

        public Customer(CustomerDto dto)
        {
            Price = new Price(dto.Price);
            Vp = dto.Vp;
            Name = dto.Name;
        }
    }
}