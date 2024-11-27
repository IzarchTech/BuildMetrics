using BuildMetrics.Lib.Interfaces;

namespace BuildMetrics.Lib.Column;

/// <summary>
/// Rectangular column
/// </summary>
/// <param name="width">Width of the column</param>
/// <param name="breadth">Breadth of the column</param>
/// <param name="height">Height of the column</param>
public class RectangularColumn(
    double width,
    double breadth,
    double height) : IFormWork, IConcrete
{
    #region Public Members

    /// <summary>
    /// Width of the column
    /// </summary>
    public double Width { get; } = width <= 0.0 ? throw new ArgumentException("width must be greater than 0.0") : width;

    /// <summary>
    /// Breadth of the column
    /// </summary>
    public double Breadth { get; } =
        breadth <= 0.0 ? throw new ArgumentException("breadth must be greater than 0.0") : breadth;

    /// <summary>
    /// Height of the column
    /// </summary>
    public double Height { get; } =
        height <= 0.0 ? throw new ArgumentException("height must be greater than 0.0") : height;

    #endregion

    #region Public Methods

    /// <inheritdoc cref="IFormWork.GetAreaOfFormWork"/>
    public double GetAreaOfFormWork()
    {
        return 2 * Height * (Width + Breadth);
    }

    /// <inheritdoc cref="IConcrete.GetVolumeOfConcrete"/>
    public double GetVolumeOfConcrete()
    {
        return Width * Breadth * Height;
    }

    #endregion
}