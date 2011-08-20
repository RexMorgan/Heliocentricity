using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Heliocentricity.Common.Loaders;
using Heliocentricity.Common.Locators;
using Heliocentricity.Common.Logging;

namespace Heliocentricity.Loaders
{
    public class ModelCollectionLoader : IModelCollectionLoader
    {
        private readonly IDirectoryLocator _directoryLocator;
        private readonly IModelLoader _modelLoader;
        private readonly ILogger _logger;

        public ModelCollectionLoader(IDirectoryLocator directoryLocator, IModelLoader modelLoader, ILogger logger)
        {
            _directoryLocator = directoryLocator;
            _logger = logger;
            _modelLoader = modelLoader;
        }

        public dynamic LoadModelCollection(RunnerOptions runnerOptions)
        {
            var modelCollection = new ExpandoObject();
            var m = modelCollection as IDictionary<string, object>;
            _logger.Info("Loading directories...");
            var directories = _directoryLocator.Directories(runnerOptions);
            _logger.Info(string.Format("Loaded {0} directories.", directories.Count()));
            foreach(var directory in directories)
            {
                var modelName = Path.GetFileName(directory).TrimStart('_');
                _logger.Info(string.Format("Loading {0}...", modelName));
                if(string.IsNullOrEmpty(modelName))
                {
                    _logger.Warn("ModelName cannot be null or empty. Skipping...");
                    continue;
                }

                var model = _modelLoader.LoadModel(runnerOptions, directory);
                m[modelName] = model;
            }
            return modelCollection;
        }
    }
}