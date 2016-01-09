using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;

namespace Core.Controllers
{
    public class PriceController
    {
        public Dictionary<Gem, int> Gems { get; }

        public PriceController(int blue, int red, int black, int green, int white)
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

        public PriceController(PriceDto dto)
        {
            Gems = dto.Gems.ToDictionary(x => x.Gem, x => x.Count);
        }
    }
}