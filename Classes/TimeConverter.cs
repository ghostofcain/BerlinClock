using System;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private readonly Func<byte, byte, byte, IBerlinClock> _factory;

        public TimeConverter()
        {
            // provide a default factory
            _factory = (hours, minutes, seconds) => new BerlinClockImpl(hours, minutes, seconds);
        }

        public TimeConverter(Func<byte, byte, byte, IBerlinClock> factory)
        {
            _factory = factory;
        }

        public string ConvertTime(string aTime)
        {
            var hourMinuteSecond = HourMinuteSecond.Parse(aTime);
            IBerlinClock berlinClock = _factory(hourMinuteSecond.Hour, hourMinuteSecond.Minute, hourMinuteSecond.Second);
            return berlinClock.GetStringRepresentation();
        }

        private class HourMinuteSecond
        {
            private HourMinuteSecond(byte hour, byte minute, byte second)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
            }

            public static HourMinuteSecond Parse(string aTime)
            {
                // Note: the reason i'm not using DateTime.TryParse here is because it would include additional logic to parse 24:00:00
                // since 24 does not exist in the Gregorian calendar and hour must be between 0-23 exclusive,
                // therefore,, to support 24:00:00 format, we will need to replace 24 with 00 and use the hour/minute/second constructor instead of DateTime
                // constructor which doesn't really add value.
                // The string is also very simplistic so I didn't want to write a regex to parse it since it wouldn't add any value in my opinion

                if (string.IsNullOrEmpty(aTime))
                {
                    throw new ArgumentException($"Expected strting in the format of HH:mm:ss but received {aTime}");
                }

                string[] split = aTime.Split(new[] {':'}, StringSplitOptions.None);
                if (split.Length != 3)
                {
                    throw new ArgumentException($"Expected strting in the format of HH:mm:ss but received {aTime}");
                }

                if (!byte.TryParse(split[0], out byte hour))
                {
                    throw new ArgumentException($"Hour should be a number and between 0 and 24 but was parsed as {hour}");
                }

                if (!byte.TryParse(split[1], out byte minute))
                {
                    throw new ArgumentException($"Minute should be between 0 and 60 but was parsed as {hour}");
                }

                if (!byte.TryParse(split[2], out byte second))
                {
                    throw new ArgumentException($"Second should be between 0 and 60 but was parsed as {hour}");
                }

                return new HourMinuteSecond(hour, minute, second);
            }

            public byte Hour { get; }
            public byte Minute { get; }
            public byte Second { get; }
        }
    }
}