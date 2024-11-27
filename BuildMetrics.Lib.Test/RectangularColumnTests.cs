using BuildMetrics.Lib.Column;

namespace BuildMetrics.Lib.Test;

[TestFixture, Description("Rectangular column tests")]
public class RectangularColumnTests
{
    [TestCase(0.225, 0.225, 3.8, 0.19)]
    [TestCase(0.9, 0.45, 3.8, 1.54)]
    public void VolumeOfConcreteTest(double width, double breadth, double height, double expectedResult)
    {
        var rc = new RectangularColumn(width, breadth, height);
        Assert.That(rc.GetVolumeOfConcrete(), Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.225, 0.225, 3.8, 3.42)]
    [TestCase(0.9, 0.45, 3.8, 10.26)]
    public void AreaOfFormworkTest(double width, double breadth, double height, double expectedResult)
    {
        var rc = new RectangularColumn(width, breadth, height);
        Assert.That(rc.GetAreaOfFormWork(), Is.EqualTo(expectedResult).Within(0.01));
    }
}