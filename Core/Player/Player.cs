using Core.Entities;

namespace Core.Player
{
    public class Player
    {
        public PlayerData PlayerData { get; private set; }

        public IPlayerConnection Connection { get; private set; }

        public Player(PlayerData data, IPlayerConnection connection)
        {
            PlayerData = data;
            Connection = connection;
        }
    }
}