using BuildMetrics.Lib.Interfaces;

namespace BuildMetrics.Lib.Drain;

/// <summary>
/// Rectangular drain
/// </summary>
/// <param name="width">Drain width</param>
/// <param name="depth">Drain depth</param>
/// <param name="span">Span</param>
/// <param name="thickness">Thickness of concrete</param>
/// <param name="blindingThickness">Blinding concrete thickness</param>
/// <param name="workingAllowance">Working allowance</param>
public class RectangularDrain(
    double width,
    double depth,
    double span,
    double thickness,
    double blindingThickness,
    double workingAllowance) : IExcavation, IBlinding, IFormWork, IConcrete
{
    #region Public Members

    /// <summary>
    /// Width of drain
    /// </summary>
    public double Width { get; } =
        width <= 0.0 ? throw new ArgumentException("Width should be greater than 0.0") : width;

    /// <summary>
    /// Depth of drain
    /// </summary>
    public double Depth { get; } =
        depth <= 0.0 ? throw new ArgumentException("Depth should be greater than 0.0") : depth;

    /// <summary>
    /// Span of drain
    /// </summary>
    public double Span { get; } = span <= 0.0 ? throw new ArgumentException("Span should be greater than 0.0") : span;

    /// <summary>
    /// Thickness of concrete
    /// </summary>
    public double Thickness { get; } =
        span <= 0.0 ? throw new ArgumentException("Thickness should be greater than 0.0") : thickness;

    /// <summary>
    /// Blinding concrete thickness
    /// </summary>
    public double BlindingThickness { get; } =
        span < 0.0 ? throw new ArgumentException("Blinding thickness should not be less than 0.0") : blindingThickness;

    /// <summary>
    /// Working allowance
    /// </summary>
    public double WorkingAllowance { get; } =
        span < 0.0 ? throw new ArgumentException("Working allowance should not be less than 0.0") : workingAllowance;

    /// <summary>
    /// Overall drain depth
    /// </summary>
    public double DrainDepth => Depth + Thickness;

    /// <summary>
    /// Overall drain width
    /// </summary>
    public double DrainWidth => 2 * Thickness + Width;

    /// <summary>
    /// Excavation depth
    /// </summary>
    public double ExcavationDepth => DrainDepth + BlindingThickness;

    /// <summary>
    /// Excavation width
    /// </summary>
    public double ExcavationWidth => 2 * WorkingAllowance + DrainWidth;

    #endregion

    #region Public Methods

    public double GetVolumeOfExcavation()
    {
        return ExcavationWidth * ExcavationDepth * Span;
    }

    public double GetVolumeOfBlinding()
    {
        return ExcavationWidth * BlindingThickness * Span;
    }

    public double GetAreaOfFormWork()
    {
        return 2 * Span * (Depth + DrainDepth);
    }

    public double GetVolumeOfConcrete()
    {
        return (2 * DrainDepth + Width) * Span * Thickness;
    }

    #endregion
}