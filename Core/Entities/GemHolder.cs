using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;

namespace Core.Entities
{
    public class GemHolder
    {
        public GemHolder(GemRepositoryDto dto)
        {
            Gems = dto.Repository.ToDictionary(x => x.Gem, x => x.Count);
        }

        public GemHolder(int gemsCount, int goldCount)
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

        public void TransferTo(GemHolder destination, Gem gem, int count)
        {
            if (CanTransfer(gem, count))
            {
                Gems[gem] -= count;
                destination.Gems[gem] += count;
            }
            else
            {
                throw new ArgumentException(string.Format("GemHolder doesn't have {1} {0} gems", gem, count));
            }
        }

        public bool CanTransfer(Gem gem, int count)
        {
            return Gems[gem] >= count;
        }
    }
}