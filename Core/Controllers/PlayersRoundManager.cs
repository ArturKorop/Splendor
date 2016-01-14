using System.Collections.Generic;
using Core.Entities;

namespace Core.Controllers
{
    public class PlayersRoundManager : RoundManager<Player>
    {
        public PlayersRoundManager(List<Player> source) : base(source)
        {
        }
    }
}