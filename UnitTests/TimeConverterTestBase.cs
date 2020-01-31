using BerlinClock.Classes;
using NUnit.Framework;
using System;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class TimeConverterTestBase
    {
        [TestCase("00:00:00")]
        [TestCase("12:00:00")]
        [TestCase("24:00:00")]
        [TestCase("00:01:00")]
        [TestCase("00:00:01")]
        [TestCase("23:59:59")]
        public void AssertCanParseValidFormatsSuccessfully(string date)
        {
            ITimeConverter timeConverter = new TimeConverter(FactoryFunction);
            Assert.DoesNotThrow(() => timeConverter.ConvertTime(date));
        }

        [TestCase("25:00:00")]
        [TestCase("24:01:01")]
        [TestCase("00:60:00")]
        [TestCase("00:00:60")]
        [TestCase("-1:00:60")]
        [TestCase("00:-1:60")]
        [TestCase("00:00:-1")]
        public void AssertThrowsExceptionOnInvalidDates(string date)
        {
            ITimeConverter timeConverter = new TimeConverter(FactoryFunction);
            Assert.Throws<ArgumentException>(() => timeConverter.ConvertTime(date));
        }

        protected Func<byte, byte, byte, IBerlinClock> FactoryFunction => (hour, minute, second) => new BerlinClockImpl(hour, minute, second);
    }
}