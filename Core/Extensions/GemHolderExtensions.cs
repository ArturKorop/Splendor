using System.Linq;
using Core.Entities;

namespace Core.Extensions
{
    public static class GemHolderExtensions
    {
        public static bool CanTakeCustomer(this GemHolder gemHolder, Customer customer)
        {
            var customerPrice = customer.Price;

            return customerPrice.Gems.All(gem => gemHolder.Gems[gem.Key] >= gem.Value);
        }
    }
}