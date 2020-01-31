using NUnit.Framework;
using System;
using System.Text;
using BerlinClock.Classes;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class BerlinClockHourTests
    {
        [TestCase(0, "OOOO\r\nOOOO")]
        [TestCase(1, "OOOO\r\nROOO")]
        [TestCase(2, "OOOO\r\nRROO")]
        [TestCase(3, "OOOO\r\nRRRO")]
        [TestCase(4, "OOOO\r\nRRRR")]
        [TestCase(5, "ROOO\r\nOOOO")]
        [TestCase(6, "ROOO\r\nROOO")]
        [TestCase(7, "ROOO\r\nRROO")]
        [TestCase(8, "ROOO\r\nRRRO")]
        [TestCase(9, "ROOO\r\nRRRR")]
        [TestCase(10, "RROO\r\nOOOO")]
        [TestCase(11, "RROO\r\nROOO")]
        [TestCase(12, "RROO\r\nRROO")]
        [TestCase(13, "RROO\r\nRRRO")]
        [TestCase(14, "RROO\r\nRRRR")]
        [TestCase(15, "RRRO\r\nOOOO")]
        [TestCase(16, "RRRO\r\nROOO")]
        [TestCase(17, "RRRO\r\nRROO")]
        [TestCase(18, "RRRO\r\nRRRO")]
        [TestCase(19, "RRRO\r\nRRRR")]
        [TestCase(20, "RRRR\r\nOOOO")]
        [TestCase(21, "RRRR\r\nROOO")]
        [TestCase(22, "RRRR\r\nRROO")]
        [TestCase(23, "RRRR\r\nRRRO")]
        [TestCase(24, "RRRR\r\nRRRR")]
        public void TestHour(byte hour, string expectedRepresentation)
        {
            var sb = new StringBuilder();
            new BerlinClockImpl(hour, 0, 0).AppendHour(sb);
            string berlinHour = sb.ToString();
            Assert.AreEqual(expectedRepresentation, berlinHour);
        }

        [TestCase(25)]
        public void ThrowsArgumentExceptionIfHourNotInRange(byte hour)
        {
            Assert.Throws<ArgumentException>(() => new BerlinClockImpl(hour, 0, 0).AppendHour(new StringBuilder()));
        }
    }
}