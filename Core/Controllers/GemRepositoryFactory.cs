using Core.Entities;

namespace Core.Controllers
{
    public static class GemRepositoryFactory
    {
        public static GemRepository GetGemRepository(int playersCount)
        {
            var gemsCount = 7;
            if(playersCount == 2)
            {
                gemsCount = 4;
            }
            else if(playersCount == 3)
            {
                gemsCount = 5;
            }

            return new GemRepository(gemsCount, GameConfig.StartGoldCount);
        }
    }
}