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

        public Dictionary<Gem, int> Gems { get; }
    }
}
