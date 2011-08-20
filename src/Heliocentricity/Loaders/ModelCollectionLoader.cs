using System;
using System.Collections.Generic;
using System.IO;
using Heliocentricity.Common.Loaders;
using Heliocentricity.Common.Locators;

namespace Heliocentricity.Loaders
{
    public class ModelCollectionLoader : IModelCollectionLoader
    {
        private readonly IDirectoryLocator _directoryLocator;
        private readonly IModelLoader _modelLoader;

        public ModelCollectionLoader(IDirectoryLocator directoryLocator, IModelLoader modelLoader)
        {
            _directoryLocator = directoryLocator;
            _modelLoader = modelLoader;
        }

        public IDictionary<string, IList<dynamic>> LoadModelCollection(RunnerOptions runnerOptions)
        {
            var modelCollection = new Dictionary<string, IList<dynamic>>();
            var directories = _directoryLocator.Directories(runnerOptions);
            foreach(var directory in directories)
            {
                var modelName = Path.GetFileName(directory).TrimStart('_');
                if(string.IsNullOrEmpty(modelName))
                {
                    throw new InvalidOperationException("ModelName cannot be null.");
                }

                var model = _modelLoader.LoadModel(runnerOptions, directory);
                modelCollection.Add(modelName, model);
            }
            return modelCollection;
        }
    }
}