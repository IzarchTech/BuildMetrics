using BuildMetrics.Lib.Culvert;

namespace BuildMetrics.Lib.Test;

[TestFixture, Description("Box culvert tests")]
public class BoxCulvertTests
{
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 1u, 1.35)]
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 3u, 3.6)]
    public void CulvertWidthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);
        Assert.That(bc.CulvertWidth, Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 1u, 1.35)]
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 3u, 1.35)]
    public void CulvertDepthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);
        Assert.That(bc.CulvertDepth, Is.EqualTo(expectedResult).Within(0.01));
    }


    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 1u, 1.4)]
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 3u, 1.4)]
    public void ExcavationDepthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.ExcavationDepth, Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 1u, 1.8)]
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 3u, 4.05)]
    public void ExcavationWidthTest(double width, double depth, double span, double thickness, double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.ExcavationWidth, Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 1u, 1.01)]
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 3u, 2.43)]
    public void VolumeOfConcreteTest(double width, double depth, double span, double thickness,
        double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.GetVolumeOfConcrete(), Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 1u, 2.52)]
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 3u, 5.67)]
    public void VolumeOfExcavationTest(double width, double depth, double span, double thickness,
        double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.GetVolumeOfExcavation(), Is.EqualTo(expectedResult).Within(0.01));
    }

    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 1u, 0.09)]
    [TestCase(0.9, 0.9, 1.0, 0.225, 0.05, 0.225, 3u, 0.2)]
    public void VolumeOfBlindingTest(double width, double depth, double span, double thickness,
        double blindingThickness,
        double workingAllowance, uint noOfCells, double expectedResult)
    {
        var bc = new BoxCulvert(width, depth, span, thickness, blindingThickness, workingAllowance, noOfCells);

        Assert.That(bc.GetVolumeOfBlinding(), Is.EqualTo(expectedResult).Within(0.01));
    }
}