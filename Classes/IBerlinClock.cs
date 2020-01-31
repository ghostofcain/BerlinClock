namespace BerlinClock.Classes
{
    /// <summary>
    /// Interface representing a BerlinClock object
    /// </summary>
    public interface IBerlinClock
    {
        /// <summary>
        /// Get the string representation of the Berlin Clock
        /// For details, see https://github.com/mazhewitt/DotNetBerlinClock
        /// </summary>
        string GetStringRepresentation();
    }
}