using System.Collections.Generic;

namespace Heliocentricity.Common.Loaders
{
    public interface IModelCollectionLoader
    {
        IDictionary<string, IList<dynamic>> LoadModelCollection(RunnerOptions runnerOptions);
    }
}