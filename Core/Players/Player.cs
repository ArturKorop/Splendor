using Core.Entities;

namespace Core.Players
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