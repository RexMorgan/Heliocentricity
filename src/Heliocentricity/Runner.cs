using System;
using Heliocentricity.Common;
using Heliocentricity.Common.Loaders;
using Heliocentricity.Common.Logging;

namespace Heliocentricity
{
    public class Runner : IRunner
    {
        private readonly ILogger _logger;
        private readonly IModelCollectionLoader _modelCollectionLoader;

        public Runner(ILogger logger, IModelCollectionLoader modelCollectionLoader)
        {
            _logger = logger;
            _modelCollectionLoader = modelCollectionLoader;
        }

        public void Run(RunnerOptions runnerOptions)
        {
            if(runnerOptions == null)
            {
                throw new ArgumentNullException("runnerOptions");
            }

            _logger.Debug(runnerOptions.WorkingDirectory);

            var modelCollection = _modelCollectionLoader.LoadModelCollection(runnerOptions);
        }
    }
}