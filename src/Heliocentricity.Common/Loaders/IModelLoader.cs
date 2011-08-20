using System.Collections.Generic;

namespace Heliocentricity.Common.Loaders
{
    public interface IModelLoader
    {
        IList<object> LoadModel(RunnerOptions runnerOptions, string directory);
    }
}