using System.Collections.Generic;

namespace Core.Dto
{
    public class GameDto
    {
        public List<PlayerDto> PlayersData { get; set; }

        public List<CustomerDto> Customers { get; set; }

        public GemHolderDto GemHolder { get; set; }

        public CardHolderDto CardHolder { get; set; }

        public GameRoundManagerDto GameRoundManager { get; set; }
    }
}