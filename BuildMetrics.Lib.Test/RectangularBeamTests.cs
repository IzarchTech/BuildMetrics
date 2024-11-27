using BuildMetrics.Lib.Beam;

namespace BuildMetrics.Lib.Test;

[TestFixture, Description("Rectangular beam tests")]
public class RectangularBeamTests
{
    [TestCase(0.225, 0.225, 1.0, 0.05)]
    [TestCase(1.2, 1.3, 1.0, 1.56)]
    public void VolumeOfConcreteTest(double width, double depth, double span, double expectedResult)
    {
        
        var rb = new RectangularBeam(width, depth, span);

        Assert.That(rb.GetVolumeOfConcrete(), Is.EqualTo(expectedResult).Within(0.01));
    }
}