using BuildMetrics.Lib.Interfaces;

namespace BuildMetrics.Lib.Column;

/// <summary>
/// Circular column
/// </summary>
/// <param name="radius">Radius of the column</param>
/// <param name="height">Height of the column</param>
public class CircularColumn(
    double radius,
    double height) : IFormWork, IConcrete
{
    #region Public Members

    /// <summary>
    /// Radius of the column
    /// </summary>
    public double Radius { get; } =
        radius <= 0.0 ? throw new ArgumentException("radius must be greater than 0.0") : radius;

    /// <summary>
    /// Height of the column
    /// </summary>
    public double Height { get; } =
        height <= 0.0 ? throw new ArgumentException("height must be greater than 0.0") : height;

    #endregion

    #region Public Members

    /// <inheritdoc cref="IFormWork.GetAreaOfFormWork"/>
    /// <remarks>
    /// Lateral area only
    /// </remarks>
    public double GetAreaOfFormWork()
    {
        // Lateral area
        return 2 * Math.PI * Radius * Height;
    }

    /// <inheritdoc cref="IConcrete.GetVolumeOfConcrete"/>
    public double GetVolumeOfConcrete()
    {
        return Math.PI * Math.Pow(Radius, 2) * Height;
    }

    /// <summary>
    /// Create a circular column with the given diameter and height
    /// </summary>
    /// <param name="diameter">Diameter of the column</param>
    /// <param name="height">Height of the column</param>
    /// <returns></returns>
    public static CircularColumn CreateWithDiameter(double diameter, double height) => diameter <= 0.0
        ? throw new ArgumentException("diameter must be greater than 0.0")
        : new CircularColumn(diameter / 2.0, height);

    #endregion
}