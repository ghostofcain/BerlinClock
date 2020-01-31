using System;
using System.Text;

namespace BerlinClock.Classes
{
    public sealed class BerlinClockImpl : IBerlinClock
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;

        public BerlinClockImpl(byte hours, byte minutes, byte seconds)
        {
            if ((hours == 24 && (minutes > 0 || seconds > 0) || hours > 24 || minutes > 59 || seconds > 59))
            {
                throw new ArgumentException("Expected a value between 00:00:00 and 24:00:00");
            }

            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

        /// <inheritdoc cref="IBerlinClock"/>
        public string GetStringRepresentation()
        {
            var sb = new StringBuilder();
            ConvertSecond(sb);
            sb.AppendLine();
            ConvertHour(sb);
            sb.AppendLine();
            ConvertMinutes(sb);
            return sb.ToString();
        }

        public override string ToString()
        {
            return GetStringRepresentation();
        }

        internal void ConvertSecond(StringBuilder stringBuilder)
        {
            stringBuilder.Append(_seconds % 2 == 0 ? "Y" : "O");
        }

        internal void ConvertHour(StringBuilder stringBuilder)
        {
            int hourDivisibleBy5 = _hours / 5;

            // first 4 rows represent 5 hour chunks
            for (int i = 0; i < 4; i++)
            {
                stringBuilder.Append(i < hourDivisibleBy5 ? "R" : "O");
            }

            stringBuilder.AppendLine();

            // second 4 rows represent the remaining hours
            int remainder = _hours % 5;
            for (int i = 0; i < 4; i++)
            {
                stringBuilder.Append(i < remainder ? "R" : "O");
            }
        }

        internal void ConvertMinutes(StringBuilder stringBuilder)
        {
            // In the first row every lamp represents 5 minutes.
            int divisibleBy5 = _minutes / 5;
            for (int i = 0; i < 11; i++)
            {
                if (i < divisibleBy5)
                {
                    // In this first row the 3rd, 6th and 9th lamp are red and indicate the first quarter,
                    // half and last quarter of an hour.The other lamps are yellow.
                    stringBuilder.Append(i > 0 && (i + 1) % 3 == 0 ? "R" : "Y");
                }
                else
                {
                    stringBuilder.Append("O");
                }
            }

            stringBuilder.AppendLine();

            // the second row with 4 lamps lamps represents the remaining minutes.
            int remainder = _minutes % 5;
            for (int i = 0; i < 4; i++)
            {
                stringBuilder.Append(i < remainder ? "Y" : "O");
            }
        }
    }
}