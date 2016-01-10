using Core.Common;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class GameStorageTests
    {
        [Test]
        public void GameStorage_Init_Successfull()
        {
            var storage = new GameStorage(@"E:\git\Splendor\Core.Test\bin\Debug\Cards.xml");

            var test = storage.Save();
        }
    }
}
