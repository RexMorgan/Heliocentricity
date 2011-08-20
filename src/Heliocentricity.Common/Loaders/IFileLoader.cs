namespace Heliocentricity.Common.Loaders
{
    public interface IFileLoader
    {
        dynamic LoadFile(RunnerOptions runnerOptions, string fileName);
    }
}