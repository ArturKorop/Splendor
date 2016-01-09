using Core.Dto;

namespace Core.Controllers
{
    public class CustomerController
    {
        public PriceController Price { get; }

        public int Vp { get; }

        public CustomerController(PriceController price, int vp)
        {
            Price = price;
            Vp = vp;
        }

        public CustomerController(CustomerDto dto)
        {
            Price = new PriceController(dto.PriceDto);
            Vp = dto.Vp;
        }
    }
}