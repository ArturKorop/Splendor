using System.Collections.Generic;
using Core.Common;
using Core.Players;
using Core.Players.Entities;

namespace Core.Controllers
{
    public class PlayersCircularManager : CircularManager<Player>
    {
        public PlayersCircularManager(List<Player> source) : base(source)
        {
        }
    }
}