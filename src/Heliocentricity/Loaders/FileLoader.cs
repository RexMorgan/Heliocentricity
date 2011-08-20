using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using Heliocentricity.Common.Loaders;
using Heliocentricity.Common.Logging;

namespace Heliocentricity.Loaders
{
    public class FileLoader : IFileLoader
    {
        private readonly ILogger _logger;
        private readonly IPropertySplitter _propertySplitter;

        public FileLoader(ILogger logger, IPropertySplitter propertySplitter)
        {
            _logger = logger;
            _propertySplitter = propertySplitter;
        }

        public dynamic LoadFile(RunnerOptions runnerOptions, string fileName)
        {
            try
            {
                var fileContents = File.ReadAllLines(fileName);
                dynamic file = new ExpandoObject();
                var f = file as IDictionary<string, object>;
                var loadingContent = false;
                var contentBuilder = new StringBuilder();
                foreach(var line in fileContents)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        loadingContent = true;
                        continue;
                    }

                    if(!loadingContent)
                    {
                        f[_propertySplitter.GetKey(line)] = _propertySplitter.GetValue(line);
                    }
                    else
                    {
                        contentBuilder.AppendLine(line);
                    }
                }

                var content = contentBuilder.ToString();
                if(!string.IsNullOrWhiteSpace(content))
                {
                    f["content"] = content;
                }

                return file;
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("{0} while loading file {1}.", ex.GetType().Name, fileName));
            }
            return null;
        }
    }
}