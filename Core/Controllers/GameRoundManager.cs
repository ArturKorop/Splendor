using System.Collections.Generic;
using System.Linq;

namespace Core.Controllers
{
    public class GameRoundManager
    {
        private readonly Dictionary<int, PlayerRoundStatus> _currentStatus;

        public GameRoundManager(List<int> playerIds)
        {
            CurrentRound = 0;
            _currentStatus = playerIds.ToDictionary(x => x, x => new PlayerRoundStatus());
        }

        public int CurrentRound { get; private set; }

        public IDictionary<int, PlayerRoundStatus> CurrentStatus => _currentStatus;

        public void NextRound()
        {
            CurrentRound++;
            foreach (var playerRoundStatuse in _currentStatus)
            {
                playerRoundStatuse.Value.Clear();
            }
        }

        public PlayerRoundStatus GetPlayerRoundStatus(int id)
        {
            return _currentStatus[id];
        }
    }
}