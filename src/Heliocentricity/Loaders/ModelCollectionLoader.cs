using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public dynamic LoadModelCollection(RunnerOptions runnerOptions)
        {
            var modelCollection = new ExpandoObject();
            var m = modelCollection as IDictionary<string, object>;
            var directories = _directoryLocator.Directories(runnerOptions);
            foreach(var directory in directories)
            {
                var modelName = Path.GetFileName(directory).TrimStart('_');
                if(string.IsNullOrEmpty(modelName))
                {
                    throw new InvalidOperationException("ModelName cannot be null.");
                }

                var model = _modelLoader.LoadModel(runnerOptions, directory);
                m[modelName] = model;
            }
            return modelCollection;
        }
    }
}