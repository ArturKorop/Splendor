using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Dto;

namespace Core.Controllers
{
    public class GemRepositoryController
    {
        public GemRepositoryController()
        {
            Gems = new Dictionary<Gem, int>();
        }

        public GemRepositoryController(GemRepositoryDto dto)
        {
            Gems = dto.Repository.ToDictionary(x => x.Gem, x => x.Count);
        }

        public Dictionary<Gem, int> Gems { get; }
    }
}