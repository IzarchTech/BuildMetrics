using BuildMetrics.Lib.Interfaces;

namespace BuildMetrics.Lib.Culvert;

/// <summary>
/// Box culvert
/// </summary>
/// <param name="width">Width of the cell</param>
/// <param name="depth">Depth of the cell</param>
/// <param name="span">Span</param>
/// <param name="blindingThickness">Blinding thickness</param>
/// <param name="workingAllowance">Working allowance</param>
/// <param name="noOfCells">Number of cells</param>
public class BoxCulvert(
    double width,
    double depth,
    double span,
    double thickness,
    double blindingThickness,
    double workingAllowance,
    uint noOfCells) : IExcavation, IBlinding, IFormWork, IConcrete
{
    #region Public Members

    /// <summary>
    /// No of cells
    /// </summary>
    public uint NoOfCells { get; } =
        noOfCells < 1 ? throw new ArgumentException("No of cell should be at least 1") : noOfCells;

    /// <summary>
    /// Width of the cell
    /// </summary>
    public double Width { get; } =
        width <= 0.0 ? throw new ArgumentException("Width should be greater than 0.0") : width;

    /// <summary>
    /// Depth of the cell
    /// </summary>
    public double Depth { get; } =
        depth <= 0.0 ? throw new ArgumentException("Depth should be greater than 0.0") : depth;

    /// <summary>
    /// Thickness of the culvert
    /// </summary>
    public double Thickness { get; } =
        thickness <= 0.0 ? throw new ArgumentException("Thickness should be greater than 0.0") : thickness;

    /// <summary>
    /// Span of the culvert
    /// </summary>
    public double Span { get; } = span <= 0.0 ? throw new ArgumentException("Span should be greater than 0.0") : span;

    /// <summary>
    /// Blinding thickness
    /// </summary>
    public double BlindingThickness { get; } = blindingThickness < 0.0
        ? throw new ArgumentException("Blinding thickness should be greater than or equal 0.0")
        : blindingThickness;

    /// <summary>
    /// Working allowance
    /// </summary>
    public double WorkingAllowance { get; } = workingAllowance < 0.0
        ? throw new ArgumentException("Working allowance should be greater than 0.0")
        : workingAllowance;

    /// <summary>
    /// Culvert depth
    /// </summary>
    public double CulvertDepth => Depth + 2 * Thickness;

    /// <summary>
    /// Excavation depth
    /// </summary>
    public double ExcavationDepth => CulvertDepth + BlindingThickness;

    /// <summary>
    /// Culvert width
    /// </summary>
    public double CulvertWidth => Thickness * (NoOfCells + 1) + NoOfCells * Width;

    /// <summary>
    /// Excavation width
    /// </summary>
    public double ExcavationWidth => CulvertWidth + 2 * WorkingAllowance;

    #endregion

    #region Public Methods

    public double GetVolumeOfBlinding()
    {
        return ExcavationWidth * BlindingThickness * Span;
    }

    public double GetVolumeOfExcavation()
    {
        return ExcavationDepth * ExcavationWidth * Span;
    }

    public double GetAreaOfFormWork()
    {
        var innerFace = (2 * Depth + Width) * Span;
        var outerFace = 2 * CulvertDepth * Span;
        var fluidFlowFace = 2 * (GetAreaOfFluidFlowFace() - GetAreaOfHollowSection());

        return innerFace + outerFace + fluidFlowFace;
    }

    public double GetVolumeOfConcrete()
    {
        return Span * (GetAreaOfFluidFlowFace() - GetAreaOfHollowSection());
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Get area of hollow section
    /// </summary>
    /// <returns>Area of hollow section</returns>
    private double GetAreaOfHollowSection()
    {
        return NoOfCells * Width * Depth;
    }

    /// <summary>
    /// Get area of fluid flow face section
    /// </summary>
    /// <returns>Area of fluid flow face</returns>
    private double GetAreaOfFluidFlowFace()
    {
        return CulvertWidth * CulvertDepth;
    }

    #endregion
}