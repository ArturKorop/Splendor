using System.Collections.Generic;

namespace Core.Dto
{
    public class PlayerDto
    {
        public int Id { get; set; }

        public GemRepositoryDto Gems { get; set; }

        public List<CardDto> BoughtCards { get; set; }

        public List<CardDto> BookedCards { get; set; }

        public List<CustomerDto> Customers { get; set; }
    }
}