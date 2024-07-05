using BuildMetrics.Lib.Drain;

namespace BuildMetrics.Lib.Test;

[TestFixture, Description("Rectangular drain tests")]
public class RectangularDrainTests
{
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 0.83)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 1.65)]
    public void DrainDepthTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.DrainDepth, Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 1.05)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 1.8)]
    public void DrainWidthTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.DrainWidth, Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 1.5)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 2.25)]
    public void ExcavationWidthTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.ExcavationWidth, Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 0.88)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 1.7)]
    public void ExcavationDepthTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.ExcavationDepth, Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 0.51)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 0.72)]
    public void VolumeOfConcreteTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.GetVolumeOfConcrete(), Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 2.85)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 6.3)]
    public void AreaOfFormWorkTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.GetAreaOfFormWork(), Is.EqualTo(expectedResult).Within(0.001));
    }
    
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 1.313)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 3.825)]
    public void VolumeOfExcavationTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.GetVolumeOfExcavation(), Is.EqualTo(expectedResult).Within(0.001));
    }
    
    [TestCase(0.6, 0.6, 1.0, 0.225,0.05, 0.225, 0.075)]
    [TestCase(1.5, 1.5, 1.0, 0.15,0.05, 0.225, 0.113)]
    public void VolumeOfBlindingTest(double width,
        double depth,
        double span,
        double thickness,
        double blindingThickness,
        double workingAllowance,
        double expectedResult)
    {
        var rd = new RectangularDrain(width, depth, span, thickness, blindingThickness, workingAllowance);
        Assert.That(rd.GetVolumeOfBlinding(), Is.EqualTo(expectedResult).Within(0.001));
    }
}