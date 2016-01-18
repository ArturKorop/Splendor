namespace Core.Entities
{
    public class GameConfig
    {
        public const int StartGoldCount = 5;
        private readonly int _playersCount;

        public GameConfig(int playersCount)
        {
            _playersCount = playersCount;
        }

        public int CustomersCount => _playersCount - 1;

        public int StartGemsCount
        {
            get
            {
                var gemsCount = 7;
                if (_playersCount == 2)
                {
                    gemsCount = 4;
                }
                else if (_playersCount == 3)
                {
                    gemsCount = 5;
                }

                return gemsCount;
            }
        }
    }
}