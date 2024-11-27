using BuildMetrics.Lib.Interfaces;

namespace BuildMetrics.Lib.Beam;

/// <summary>
/// Rectangular beam
/// </summary>
/// <param name="width">Width of the beam</param>
/// <param name="depth">Depth of the beam</param>
/// <param name="span">Span of the beam</param>
public class RectangularBeam(
    double width,
    double depth,
    double span) : IFormWork, IConcrete
{
    #region Public Members

    /// <summary>
    /// Width of the beam
    /// </summary>
    public double Width { get; } = width <= 0 ? throw new ArgumentException("width should be greater than 0.0") : width;

    /// <summary>
    /// Depth of the beam
    /// </summary>
    public double Depth { get; } = depth <= 0 ? throw new ArgumentException("depth should be greater than 0.0") : depth;

    /// <summary>
    /// Span of the beam
    /// </summary>
    public double Span { get; } = span <= 0 ? throw new ArgumentException("span should be greater than 0.0") : span;

    #endregion

    #region Public Methods

    public double GetAreaOfFormWork()
    {
        return 2 * Span * (Depth + Width);
    }

    public double GetVolumeOfConcrete()
    {
        return Span * Depth * Width;
    }

    #endregion
}