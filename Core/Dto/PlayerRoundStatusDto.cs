using Core.Controllers;
using Core.Entities;

namespace Core.Dto
{
    public class PlayerRoundStatusDto
    {
        public int Id { get; set; }

        public PlayerRoundStatus Status { get; set; }
    }
}