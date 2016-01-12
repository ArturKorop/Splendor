using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;

namespace Core.Entities
{
    public class GemRepository
    {
        public GemRepository()
        {
            Gems = new Dictionary<Gem, int>();
        }

        public GemRepository(GemRepositoryDto dto)
        {
            Gems = dto.Repository.ToDictionary(x => x.Gem, x => x.Count);
        }

        public GemRepository(int gemsCount, int goldCount)
        {
            Gems = new Dictionary<Gem, int>
            {
                {Gem.Black, gemsCount},
                {Gem.Blue, gemsCount},
                {Gem.White, gemsCount},
                {Gem.Red, gemsCount},
                {Gem.Green, gemsCount},
                {Gem.Gold, goldCount}
            };
        }

        public Dictionary<Gem, int> Gems { get; }
    }
}