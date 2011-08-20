using System.Collections.Generic;
using System.IO;
using Heliocentricity.Common.Loaders;
using Heliocentricity.Common.Logging;

namespace Heliocentricity.Loaders
{
    public class ModelLoader : IModelLoader
    {
        private readonly IFileLoader _fileLoader;
        private readonly ILogger _logger;

        public ModelLoader(IFileLoader fileLoader, ILogger logger)
        {
            _fileLoader = fileLoader;
            _logger = logger;
        }

        public IList<dynamic> LoadModel(RunnerOptions runnerOptions, string directory)
        {
            var model = new List<dynamic>();

            var files = Directory.GetFiles(directory, "*.markdown", SearchOption.AllDirectories);
            _logger.Info(string.Format("Found {0} files to load...", files.Length));
            foreach(var file in files)
            {
                var fileModel = _fileLoader.LoadFile(runnerOptions, file);
                model.Add(fileModel);
            }

            return model;
        }
    }
}