using BuildMetrics.Lib.Column;

namespace BuildMetrics.Lib.Test;

[TestFixture, Description("Circular column tests")]
public class CircularColumnTests
{
    [TestCase(0.3, 3.8, 1.07)]
    [TestCase(0.45, 3.1, 1.97)]
    public void VolumeOfConcreteTest(double radius, double height, double expectedResult)
    {
        var cc = new CircularColumn(radius, height);
        Assert.That(cc.GetVolumeOfConcrete(), Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.3, 3.8, 7.16)]
    [TestCase(0.45, 3.1, 8.77)]
    public void AreaOfFormworkTest(double radius, double height, double expectedResult)
    {
        var cc = new CircularColumn(radius, height);
        Assert.That(cc.GetAreaOfFormWork(), Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.6, 3.8, 1.07)]
    [TestCase(0.9, 3.1, 1.97)]
    public void VolumeOfConcreteWithDiameterTest(double diameter, double height, double expectedResult)
    {
        var cc = CircularColumn.CreateWithDiameter(diameter, height);
        Assert.That(cc.GetVolumeOfConcrete(), Is.EqualTo(expectedResult).Within(0.01));
    }
    
    [TestCase(0.6, 3.8, 7.16)]
    [TestCase(0.9, 3.1, 8.77)]
    public void AreaOfFormworkWithDiameterTest(double diameter, double height, double expectedResult)
    {
        var cc = CircularColumn.CreateWithDiameter(diameter, height);
        Assert.That(cc.GetAreaOfFormWork(), Is.EqualTo(expectedResult).Within(0.01));
    }
}