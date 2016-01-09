using System.Collections.Generic;

namespace Core.Dto
{
    public class PlayerDto
    {
        public PlayerDto(int id)
        {
            Id = id;
            Gems = new GemRepositoryDto();
            BookedCards = new List<CardDto>();
            BoughtCards = new List<CardDto>();
            Customers = new List<CustomerDto>();
        }

        public PlayerDto() : this(0)
        { }

        public int Id { get; set; }

        public GemRepositoryDto Gems { get; set; }

        public List<CardDto> BoughtCards { get; set; }

        public List<CardDto> BookedCards { get; set; }

        public List<CustomerDto> Customers { get; set; }
    }
}