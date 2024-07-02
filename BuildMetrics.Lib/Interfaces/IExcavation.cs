namespace BuildMetrics.Lib.Interfaces;

public interface IExcavation
{
    /// <summary>
    /// Get volume of earth to be excavated
    /// </summary>
    /// <returns>Volume of excavation</returns>
    double GetVolumeOfExcavation();
}