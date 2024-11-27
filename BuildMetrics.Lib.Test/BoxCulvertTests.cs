using BuildMetrics.Lib.Culvert;

namespace BuildMetrics.Lib.Test;

[TestFixture, Description("Box culvert tests")]
public class BoxCulvertTests
{
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 1.2)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 3.3)]
    public void CulvertWidthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);
        Assert.That(bc.CulvertWidth, Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 1.2)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 1.2)]
    public void CulvertDepthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);
        Assert.That(bc.CulvertDepth, Is.EqualTo(expectedResult).Within(0.01));
    }


    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 1.25)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 1.25)]
    public void ExcavationDepthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.ExcavationDepth, Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 1.65)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 3.75)]
    public void ExcavationWidthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.ExcavationWidth, Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 0.63)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 1.53)]
    public void VolumeOfConcreteTest(double width, double depth, double span, double thickness,
        double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.GetVolumeOfConcrete(), Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 2.06)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 4.69)]
    public void VolumeOfExcavationTest(double width, double depth, double span, double thickness,
        double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.GetVolumeOfExcavation(), Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 0.08)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 0.19)]
    public void VolumeOfBlindingTest(double width, double depth, double span, double thickness,
        double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.GetVolumeOfBlinding(), Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 1u, 6.36)]
    [TestCase(0.9, 0.9, 1.0, 0.15, 0.05, 0.225, 3u, 13.56)]
    public void AreaOfFormworkTest(double width, double depth, double span, double thickness,
        double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.GetAreaOfFormWork(), Is.EqualTo(expectedResult).Within(0.01));
    }
}