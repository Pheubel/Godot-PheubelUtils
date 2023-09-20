using Godot;

namespace PheubelUtils;

public static class WaveFunctions
{
    /// <summary>
    /// Returns a number between -1 and 1 on a sine wave with a wavelength equal to the inverse of the frequency.
    /// </summary>
    /// <param name="offset"> The amount the wave should be offset by.</param>
    /// <param name="x"> The position on the wavelength.</param>
    /// <param name="frequency"> The amount of times a full wave is made per second.</param>
    /// <returns> A number between -1 and 1.</returns>
    public static float Sine(float offset, float x, float frequency) =>
        Mathf.Sin((offset + (x * frequency)) * 2 * Mathf.Pi);

    /// <summary>
    /// Returns a number between -1 and 1 on a triangle wave with a wavelength equal to the inverse of the frequency.
    /// </summary>
    /// <param name="offset"> The amount the wave should be offset by.</param>
    /// <param name="x"> The position on the wavelength.</param>
    /// <param name="frequency"> The amount of times a full wave is made per second.</param>
    /// <returns> A number between -1 and 1.</returns>
    public static float Triangle(float offset, float x, float frequency) =>
        Mathf.Abs(1 - ((1.5f + offset + (x * frequency * 2)) % 2)) * 2 - 1;

    /// <summary>
    /// Returns a number between -1 and 1 on a square wave with a wavelength equal to the inverse of the frequency.
    /// </summary>
    /// <param name="offset"> The amount the wave should be offset by.</param>
    /// <param name="x"> The position on the wavelength.</param>
    /// <param name="frequency"> The amount of times a full wave is made per second.</param>
    /// <returns> A number between -1 and 1.</returns>
    public static float Square(float offset, float x, float frequency) =>
        (((0.5f + offset + (x * frequency)) % 1) >= 0.5) ? 1f : -1f;

    /// <summary>
    /// Returns a number between -1 and 1 on a sharktooth wave with a wavelength equal to the inverse of the frequency.
    /// </summary>
    /// <param name="offset"> The amount the wave should be offset by.</param>
    /// <param name="x"> The position on the wavelength.</param>
    /// <param name="frequency"> The amount of times a full wave is made per second.</param>
    /// <returns> A number between -1 and 1.</returns>
    public static float Sharktooth(float offset, float x, float frequency) =>
        ((0.5f + offset + (x * frequency)) % 1f * 2) - 1;
}
