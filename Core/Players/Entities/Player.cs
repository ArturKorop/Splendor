using Core.Entities;
using Core.Interfaces;

namespace Core.Players.Entities
{
    public class Player
    {
        public PlayerRoundStatus RoundStatus { get; private set; }

        public PlayerData PlayerData { get; private set; }

        public IPlayerConnection Connection { get; private set; }

        public Player(PlayerData data, IPlayerConnection connection)
        {
            PlayerData = data;
            Connection = connection;
            RoundStatus = new PlayerRoundStatus();
        }
    }
}