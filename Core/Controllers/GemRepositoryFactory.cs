using Core.Entities;

namespace Core.Controllers
{
    public static class GemRepositoryFactory
    {
        public static GemHolder GetGemRepository(int playersCount)
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

            return new GemHolder(gemsCount, GameConfig.StartGoldCount);
        }
    }
}