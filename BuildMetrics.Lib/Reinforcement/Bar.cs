namespace BuildMetrics.Lib.Reinforcement;

/// <summary>
/// Bar
///
/// <remarks>Reinforcement</remarks>
/// </summary>
public class Bar
{
    /// <summary>
    /// Bar weights
    ///
    /// <remarks>Unit for weight is kilogram(kg)</remarks>
    /// </summary>
    private static readonly List<double> BarWeights = [0.222, 0.395, 0.616, 0.888, 1.579, 2.466, 3.854, 6.313, 9.864];

    /// <summary>
    /// Bar size
    /// </summary>
    public BarSizes Size { get; }

    /// <summary>
    /// Bar length
    /// </summary>
    public double Length { get; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="size"></param>
    /// <param name="length"></param>
    private Bar(BarSizes size, double length)
    {
        Size = size;
        Length = length;
    }

    /// <summary>
    /// Get bar weight
    /// </summary>
    /// <returns>Weight in kilogram(kg)</returns>
    public double GetWeight()
    {
        return BarWeights[(int)Size] * Length;
    }

    /// <summary>
    /// Get bar size value
    /// </summary>
    /// <param name="size"><see cref="BarSizes"/> enum</param>
    /// <returns>Size value</returns>
    /// <exception cref="ArgumentOutOfRangeException">Invalid <see cref="BarSizes"/></exception>
    private static double GetSize(BarSizes size)
    {
        return size switch
        {
            BarSizes.BarSize6 => 6e-3,
            BarSizes.BarSize8 => 8e-3,
            BarSizes.BarSize10 => 10e-3,
            BarSizes.BarSize12 => 12e-3,
            BarSizes.BarSize16 => 16e-3,
            BarSizes.BarSize20 => 20e-3,
            BarSizes.BarSize25 => 25e-3,
            BarSizes.BarSize32 => 32e-3,
            BarSizes.BarSize40 => 40e-3,
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }

    /// <summary>
    /// Create bar with shape code 20
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <returns>Bar</returns>
    public static Bar CreateShape20(BarSizes size, double a) => new(size, a);

    /// <summary>
    /// Create bar with shape code 32
    /// </summary>]
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="h">Hook allowance</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode32(BarSizes size, double a, double h) => new(size, a + h);

    /// <summary>
    /// Create bar with shape code 33
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="h">Hook allowance</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode33(BarSizes size, double a, double h) => new(size, a + 2 * h);

    /// <summary>
    /// Create bar with shape code 34
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="n">Bend allowance</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode34(BarSizes size, double a, double n) => new(size, a + n);

    /// <summary>
    /// Create bar with shape code 35
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="n">Bend allowance</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode35(BarSizes size, double a, double n) => new(size, a + 2 * n);

    /// <summary>
    /// Create bar with shape code 36
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d</param>
    /// <param name="e">Length of segment e</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode36(BarSizes size, double a, double b, double c, double d, double e) =>
        new(size, a + c + e + 0.57 * (b + d) - Math.PI * GetSize(size));

    /// <summary>
    /// Create bar with shape code 37
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode37(BarSizes size, double a, double b, double r) =>
        new Bar(size, a + b - 0.5 * r - GetSize(size));

    /// <summary>
    /// Create bar with shape code 38
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode38(BarSizes size, double a, double b, double c, double r) =>
        new Bar(size, a + b + c - 2 * (0.5 * r + GetSize(size)));

    /// <summary>
    /// Create bar with shape code 39
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode39(BarSizes size, double a, double b, double c) =>
        // Combines segments a, b, and c with adjustments based on bar size
        new Bar(size, a + 0.57 * b + c - 0.5 * Math.PI * GetSize(size));

    /// <summary>
    /// Create bar with shape code 41
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d (band)</param>
    /// <param name="r">Radius of band</param>
    /// <exception cref="ArgumentException">d must be at least 2 * <see cref="GetSize"/></exception>
    public static Bar CreateShapeCode41(BarSizes size, double a, double b, double c, double d, double r)
    {
        if (d < 2 * GetSize(size)) throw new ArgumentException($"d must be at least {2 * GetSize(size)}");

        // Combines segments a, b, and c with adjustments based on bar size
        return new Bar(size, a + b + c);
    }

    /// <summary>
    /// Create bar with shape code 42
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="n">Bend allowance</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode42(BarSizes size, double a, double b, double c, double n) =>
        new(size, a + b + c + n);

    /// <summary>
    /// Create bar with shape code 43
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="e">Length of segment e</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode43(BarSizes size, double a, double b, double c, double e) =>
        new Bar(size, a + 2 * b + c + e);

    /// <summary>
    /// Create bar with shape code 45
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    /// <exception cref="ArgumentException">r must be at least <see cref="GetSize"/></exception>
    public static Bar CreateShapeCode45(BarSizes size, double a, double b, double c, double r)
    {
        if (r < GetSize(size)) throw new ArgumentException($"r must be at least {GetSize(size)}");

        // Combines segments a, b, and c with adjustments based on bar size
        return new Bar(size, a + b + c - 0.5 * r + GetSize(size));
    }

    /// <summary>
    /// Create bar with shape code 48
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode48(BarSizes size, double a, double b, double c) =>
        new Bar(size, a + b + c);

    /// <summary>
    /// Create bar with shape code 49
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode49(BarSizes size, double a, double b, double c) =>
        new Bar(size, a + b + c);

    /// <summary>
    /// Create bar with shape code 51
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode51(BarSizes size, double a, double b, double r) =>
        new Bar(size, a + b - 0.5 * r + GetSize(size));

    /// <summary>
    /// Create bar with shape code 52
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode52(BarSizes size, double a, double b, double c, double d, double r) =>
        new Bar(size, a + b + c + d - 3 * (0.5 * r + GetSize(size)));

    /// <summary>
    /// Create bar with shape code 53
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d</param>
    /// <param name="e">Length of segment e</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode53(BarSizes size, double a, double b, double c, double d, double e, double r) =>
        new Bar(size, a + b + c + d + e - 4 * (0.5 * r + GetSize(size)));

    /// <summary>
    /// Create bar with shape code 54
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode54(BarSizes size, double a, double b, double c, double r) =>
        new Bar(size, a + b + c - 2 * (0.5 * r + GetSize(size)));

    /// <summary>
    /// Create bar with shape code 58
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d</param>
    /// <param name="e">Length of segment e</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode58(BarSizes size, double a, double b, double c, double d, double e, double r) =>
        new Bar(size, a + b + c + d + e - 4 * (0.5 * r + GetSize(size)));

    /// <summary>
    /// Create bar with shape code 60
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode60(BarSizes size, double a, double b) =>
        new Bar(size, 2 * (a + b) + 20 * GetSize(size));

    /// <summary>
    /// Create bar with shape code 62
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="c">Length of segment c</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode62(BarSizes size, double a, double c) =>
        new Bar(size, a + c);

    /// <summary>
    /// Create bar with shape code 65
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode65(BarSizes size, double a) =>
        new Bar(size, a);

    /// <summary>
    /// Create bar with shape code 72
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode72(BarSizes size, double a, double b) =>
        new Bar(size, 2 * a + b + 25 * GetSize(size));

    /// <summary>
    /// Create bar with shape code 73
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode73(BarSizes size, double a, double b, double c) =>
        new Bar(size, 2 * a + b + c + 10 * GetSize(size));

    /// <summary>
    /// Create bar with shape code 74
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode74(BarSizes size, double a, double b) =>
        new Bar(size, 2 * a + 3 * b + 20 * GetSize(size));

    /// <summary>
    /// Create bar with shape code 75
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d</param>
    /// <param name="e">Length of segment e</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode75(BarSizes size, double a, double b, double c, double d, double e, double r) =>
        new Bar(size, a + b + c + 2 * d + e + 10 * GetSize(size));

    /// <summary>
    /// Create bar with shape code 81
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode81(BarSizes size, double a, double b) =>
        new Bar(size, 2 * a + 3 * b + 22 * GetSize(size));

    /// <summary>
    /// Create bar with shape code 83
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode83(BarSizes size, double a, double b, double c, double d, double r) =>
        new Bar(size, a + 2 * b + c + d - 4 * (0.5 * r + GetSize(size)));

    /// <summary>
    /// Create bar with shape code 85
    /// </summary>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <param name="d">Length of segment d</param>
    /// <param name="r">Radius of band</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode85(BarSizes size, double a, double b, double c, double d, double r) =>
        new Bar(size, a + b + 0.57 * c + d - 0.5 * r - 2.57 * GetSize(size));

    /// <summary>
    /// Create bar with shape code 86
    /// </summary>
    /// <remarks>
    /// This function first checks if the value of b is less than a/5.
    /// If it is, it calculates the length of the bar as c/b * pi * (a + GetSize(size)) + 8 * GetSize(size).
    /// If it is not, it throws a NotImplementedException, since the case where b > a/5 is not implemented.
    /// </remarks>
    /// <param name="size">Bar size</param>
    /// <param name="a">Length of segment a</param>
    /// <param name="b">Length of segment b</param>
    /// <param name="c">Length of segment c</param>
    /// <returns>Bar</returns>
    public static Bar CreateShapeCode86(BarSizes size, double a, double b, double c)
    {
        if (b < a / 5)
            return new Bar(size, c / b * Math.PI * (a + GetSize(size)) + 8 * GetSize(size));

        throw new NotImplementedException("Case where b > a/5 not implemented");
    }
}