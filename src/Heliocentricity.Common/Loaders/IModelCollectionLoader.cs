namespace Heliocentricity.Common.Loaders
{
    public interface IModelCollectionLoader
    {
        dynamic LoadModelCollection(RunnerOptions runnerOptions);
    }
}