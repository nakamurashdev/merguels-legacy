using System.Runtime.CompilerServices;

namespace MerguelsLegacy.Utilities;

public static class TimeUtilities
{
    private const int SECOND_IN_FRAMES = 60;

    private const int MINUTE_IN_SECONDS = 60;
    
    /// <summary>
    ///     Converts seconds to frames.
    /// </summary>
    /// <param name="seconds">
    ///     The number of seconds to convert.
    /// </param>
    /// <returns>
    ///     The number of frames in the given number of seconds.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SecondsToFrames(int seconds) => seconds * SECOND_IN_FRAMES;
    
    /// <summary>
    ///     Converts minutes to frames.
    /// </summary>
    /// <param name="minutes">
    ///     The number of minutes to convert.
    /// </param>
    /// <returns>
    ///     The number of frames in the given number of minutes.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int MinutesToFrames(int minutes) => SecondsToFrames(minutes * MINUTE_IN_SECONDS);
}