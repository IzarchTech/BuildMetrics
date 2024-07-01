namespace BuildMetrics.Lib.Interfaces;

public interface IExcavation
{
    /// <summary>
    /// Get volume of earth to be excavated
    /// </summary>
    /// <returns>Volume of excavation</returns>
    float GetVolumeOfExcavation();

    /// <summary>
    /// Get volume of earth to be carted away
    /// </summary>
    /// <returns>Volume of cart away</returns>
    float GetVolumeOfCartAway();
}