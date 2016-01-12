namespace Core.Controllers
{
    public class GameConfig
    {
        private readonly int _playersCount;

        public GameConfig(int playersCount)
        {
            _playersCount = playersCount;
        }

        public int CustomersCount => _playersCount - 1;

        public const int StartGoldCount = 5;
    }
}