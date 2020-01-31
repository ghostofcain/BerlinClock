using NUnit.Framework;
using System;
using System.Text;
using BerlinClock.Classes;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class BerlinSecondTests
    {
        [TestCase(0, "Y")]
        [TestCase(1, "O")]
        [TestCase(59, "O")]
        public void TestSecond(byte seconds, string expectedRepresentation)
        {
            var sb = new StringBuilder();
            new BerlinClockImpl(0, 0, seconds).AppendSecond(sb);
            string berlinSecond = sb.ToString();
            Assert.AreEqual(expectedRepresentation, berlinSecond);
        }

        [TestCase(60)]
        [TestCase(120)]
        public void ThrowsArgumentExceptionIfSecondNotInRange(byte seconds)
        {
            Assert.Throws<ArgumentException>(() => new BerlinClockImpl(0, 0, seconds).AppendSecond(new StringBuilder()));
        }
    }
}