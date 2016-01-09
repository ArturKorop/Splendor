using System.Collections.Generic;

namespace Core.Dto
{
    public class GemRepositoryDto
    {
        public List<GemCountDto> Repository { get; set; }

        public GemRepositoryDto()
        {
            Repository = new List<GemCountDto>();
        }
    }
}