using System.Collections.Generic;
using System.IO;
using Heliocentricity.Common.Loaders;

namespace Heliocentricity.Loaders
{
    public class ModelLoader : IModelLoader
    {
        private readonly IFileLoader _fileLoader;

        public ModelLoader(IFileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }

        public IList<dynamic> LoadModel(RunnerOptions runnerOptions, string directory)
        {
            var model = new List<dynamic>();

            var files = Directory.GetFiles(directory, "*.markdown", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                var fileModel = _fileLoader.LoadFile(runnerOptions, file);
                model.Add(fileModel);
            }

            return model;
        }
    }
}