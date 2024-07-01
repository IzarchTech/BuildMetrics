namespace BuildMetrics.Lib.Interfaces;

public interface IExcavation
{
    /// <summary>
    /// Volume of earth to be excavated
    /// </summary>
    /// <returns>Volume of excavation</returns>
    float VolumeOfExcavation();

    /// <summary>
    /// Volume of earth to be carted away
    /// </summary>
    /// <returns>Volume of cart away</returns>
    float VolumeOfCartAway();
}