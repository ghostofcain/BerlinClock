using BerlinClock.Classes;
using NUnit.Framework;
using System;

namespace BerlinClock.UnitTests
{
    public class BerlinClockTestsBase
    {
        [TestCase(0, 0, 0, "Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(24, 0, 0, "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(1, 0, 0, "Y\r\nOOOO\r\nROOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(4, 0, 0, "Y\r\nOOOO\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(5, 0, 0, "Y\r\nROOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(0, 0, 1, "O\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(0, 1, 0, "Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nYOOO")]
        public void TestClock(byte hour, byte minute, byte second, string expectedRepresentation)
        {
            // all the possible permutations are already tested inside the interal Hour/Minute/Second classes
            // so this is just a sanity check. We don't need too many of these tests except making sure that the
            // order of the output is correct (i.e. second/hour/minute)
            string berlinClockString = CreateBerlinClock(hour, minute, second).GetStringRepresentation();
            Assert.AreEqual(expectedRepresentation, berlinClockString);
        }

        [TestCase(24, 1, 1)]
        [TestCase(25, 0, 0)]
        [TestCase(0, 60, 0)]
        [TestCase(0, 0, 60)]
        public void AssertThrowsExceptionOnInvalidDates(byte hour, byte minute, byte second)
        {
            // the checks are already done inside the appropriate Hour/Minute/Second classes so 
            // these are just sanity checks instead of a full blown test suite
            Assert.Throws<ArgumentException>(() => CreateBerlinClock(hour, minute, second).GetStringRepresentation());
        }

        private IBerlinClock CreateBerlinClock(byte hour, byte minute, byte second)
        {
            return new BerlinClockImpl(hour, minute, second);
        }
    }
}