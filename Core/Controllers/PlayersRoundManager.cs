using System.Collections.Generic;

namespace Core.Controllers
{
    public class PlayersRoundManager : RoundManager<Player.Player>
    {
        public PlayersRoundManager(List<Player.Player> source) : base(source)
        {
        }
    }
}