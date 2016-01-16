using System;
using Core.Common;
using Core.Entities;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class GemHolderTests
    {
        [Test]
        public void TransferTo_Enough_Successfull()
        {
            var source = new GemHolder(5,5);
            var destination = new GemHolder(0,0);

            source.TransferTo(destination, Gem.Blue, 3);

            Assert.AreEqual(3, destination.Gems[Gem.Blue]);
        }

        [Test]
        public void TransferTo_TooLittle_Exception()
        {
            var source = new GemHolder(2, 5);
            var destination = new GemHolder(0,0);

            Assert.Throws(typeof (ArgumentException), () => source.TransferTo(destination, Gem.Blue, 3));
        }

        [Test]
        public void CanTransfer_Enough_True()
        {
            var source = new GemHolder(5,5);

            var result = source.CanTransfer(Gem.Blue, 3);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void CanTransfer_TooLittle_False()
        {
            var source = new GemHolder(2, 5);

            var result = source.CanTransfer(Gem.Blue, 3);

            Assert.AreEqual(false, result);
        }
    }
}
