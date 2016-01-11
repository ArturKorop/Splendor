using Core.Dto;

namespace Core.Entities
{
    public class Customer
    {
        public Price Price { get; }

        public int Vp { get; }

        public string Name { get; }

        public int Id { get; }

        public Customer(Price price, int vp, string name, int id)
        {
            Price = price;
            Vp = vp;
            Name = name;
            Id = id;
        }

        public Customer(CustomerDto dto)
        {
            Price = new Price(dto.Price);
            Vp = dto.Vp;
            Name = dto.Name;
            Id = dto.Id;
        }
    }
}