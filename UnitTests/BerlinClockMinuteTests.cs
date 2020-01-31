using NUnit.Framework;
using System;
using System.Text;
using BerlinClock.Classes;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class BerlinClockMinuteTests
    {
        [TestCase(0, "OOOOOOOOOOO\r\nOOOO")]
        [TestCase(1, "OOOOOOOOOOO\r\nYOOO")]
        [TestCase(2, "OOOOOOOOOOO\r\nYYOO")]
        [TestCase(3, "OOOOOOOOOOO\r\nYYYO")]
        [TestCase(4, "OOOOOOOOOOO\r\nYYYY")]
        [TestCase(5, "YOOOOOOOOOO\r\nOOOO")]
        [TestCase(6, "YOOOOOOOOOO\r\nYOOO")]
        [TestCase(7, "YOOOOOOOOOO\r\nYYOO")]
        [TestCase(8, "YOOOOOOOOOO\r\nYYYO")]
        [TestCase(9, "YOOOOOOOOOO\r\nYYYY")]
        [TestCase(10, "YYOOOOOOOOO\r\nOOOO")]
        [TestCase(11, "YYOOOOOOOOO\r\nYOOO")]
        [TestCase(12, "YYOOOOOOOOO\r\nYYOO")]
        [TestCase(13, "YYOOOOOOOOO\r\nYYYO")]
        [TestCase(14, "YYOOOOOOOOO\r\nYYYY")]
        [TestCase(15, "YYROOOOOOOO\r\nOOOO")]
        [TestCase(16, "YYROOOOOOOO\r\nYOOO")]
        [TestCase(17, "YYROOOOOOOO\r\nYYOO")]
        [TestCase(18, "YYROOOOOOOO\r\nYYYO")]
        [TestCase(19, "YYROOOOOOOO\r\nYYYY")]
        [TestCase(20, "YYRYOOOOOOO\r\nOOOO")]
        [TestCase(21, "YYRYOOOOOOO\r\nYOOO")]
        [TestCase(22, "YYRYOOOOOOO\r\nYYOO")]
        [TestCase(23, "YYRYOOOOOOO\r\nYYYO")]
        [TestCase(24, "YYRYOOOOOOO\r\nYYYY")]
        [TestCase(25, "YYRYYOOOOOO\r\nOOOO")]
        [TestCase(26, "YYRYYOOOOOO\r\nYOOO")]
        [TestCase(27, "YYRYYOOOOOO\r\nYYOO")]
        [TestCase(28, "YYRYYOOOOOO\r\nYYYO")]
        [TestCase(29, "YYRYYOOOOOO\r\nYYYY")]
        [TestCase(30, "YYRYYROOOOO\r\nOOOO")]
        [TestCase(31, "YYRYYROOOOO\r\nYOOO")]
        [TestCase(32, "YYRYYROOOOO\r\nYYOO")]
        [TestCase(33, "YYRYYROOOOO\r\nYYYO")]
        [TestCase(34, "YYRYYROOOOO\r\nYYYY")]
        [TestCase(35, "YYRYYRYOOOO\r\nOOOO")]
        [TestCase(36, "YYRYYRYOOOO\r\nYOOO")]
        [TestCase(37, "YYRYYRYOOOO\r\nYYOO")]
        [TestCase(38, "YYRYYRYOOOO\r\nYYYO")]
        [TestCase(39, "YYRYYRYOOOO\r\nYYYY")]
        [TestCase(40, "YYRYYRYYOOO\r\nOOOO")]
        [TestCase(41, "YYRYYRYYOOO\r\nYOOO")]
        [TestCase(42, "YYRYYRYYOOO\r\nYYOO")]
        [TestCase(43, "YYRYYRYYOOO\r\nYYYO")]
        [TestCase(44, "YYRYYRYYOOO\r\nYYYY")]
        [TestCase(45, "YYRYYRYYROO\r\nOOOO")]
        [TestCase(46, "YYRYYRYYROO\r\nYOOO")]
        [TestCase(47, "YYRYYRYYROO\r\nYYOO")]
        [TestCase(48, "YYRYYRYYROO\r\nYYYO")]
        [TestCase(49, "YYRYYRYYROO\r\nYYYY")]
        [TestCase(50, "YYRYYRYYRYO\r\nOOOO")]
        [TestCase(51, "YYRYYRYYRYO\r\nYOOO")]
        [TestCase(52, "YYRYYRYYRYO\r\nYYOO")]
        [TestCase(53, "YYRYYRYYRYO\r\nYYYO")]
        [TestCase(54, "YYRYYRYYRYO\r\nYYYY")]
        [TestCase(55, "YYRYYRYYRYY\r\nOOOO")]
        [TestCase(56, "YYRYYRYYRYY\r\nYOOO")]
        [TestCase(57, "YYRYYRYYRYY\r\nYYOO")]
        [TestCase(58, "YYRYYRYYRYY\r\nYYYO")]
        [TestCase(59, "YYRYYRYYRYY\r\nYYYY")]
        public void TestMinute(byte minute, string expectedRepresentation)
        {
            var sb = new StringBuilder();
            new BerlinClockImpl(0, minute, 0).ConvertMinutes(sb);
            string berlinMinute = sb.ToString();
            Assert.AreEqual(expectedRepresentation, berlinMinute);
        }

        [TestCase(60)]
        [TestCase(61)]
        [TestCase(120)]
        public void ThrowsArgumentExceptionIfMinuteNotInRange(byte minute)
        {
            Assert.Throws<ArgumentException>(() => new BerlinClockImpl(0, minute, 0).ConvertMinutes(new StringBuilder()));
        }
    }
}