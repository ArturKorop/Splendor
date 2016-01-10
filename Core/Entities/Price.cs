using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;

namespace Core.Entities
{
    public class Price
    {
        public Dictionary<Gem, int> Gems { get; }

        public Price(int blue, int red, int black, int green, int white)
        {
            Gems = new Dictionary<Gem, int>
            {
                { Gem.Black, black},
                { Gem.Blue, blue},
                { Gem.White, white},
                { Gem.Red, red},
                { Gem.Green, green},
            };
        }

        public Price(PriceDto dto)
        {
            Gems = dto.Gems.ToDictionary(x => x.Gem, x => x.Count);
        }
    }
}