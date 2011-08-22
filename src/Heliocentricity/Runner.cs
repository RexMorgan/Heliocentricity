using System;
using Heliocentricity.Common;
using Heliocentricity.Common.Loaders;
using Heliocentricity.Common.Logging;
using Heliocentricity.Correlation;

namespace Heliocentricity
{
    public class Runner : IRunner
    {
        private readonly ILogger _logger;
        private readonly IModelCollectionLoader _modelCollectionLoader;
        private readonly ICorrelator _correlator;

        public Runner(ILogger logger, IModelCollectionLoader modelCollectionLoader, ICorrelator correlator)
        {
            _logger = logger;
            _correlator = correlator;
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

            _correlator.Correlate(modelCollection, runnerOptions);
        }
    }
}