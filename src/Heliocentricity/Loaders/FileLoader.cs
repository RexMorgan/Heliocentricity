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
                _logger.Info(string.Format("Loading file {0}...", Path.GetFileName(fileName)));
                var fileContents = File.ReadAllLines(fileName);
                _logger.Debug(string.Format("Found {0} lines in file.", fileContents.Length));
                dynamic file = new ExpandoObject();
                var f = file as IDictionary<string, object>;

                if(f == null)
                {
                    _logger.Warn("Something's very wrong, ExpandoObject could not be cast to a Dictionary.");
                    return null;
                }

                f["FileName"] = Path.GetFileName(fileName);
                var loadingContent = false;
                var contentBuilder = new StringBuilder();
                foreach(var line in fileContents)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        _logger.Debug("Found break between properties and content.");
                        loadingContent = true;
                        continue;
                    }

                    if(!loadingContent)
                    {
                        var key = _propertySplitter.GetKey(line);
                        var value = _propertySplitter.GetValue(line);

                        _logger.Debug(string.Format("Adding property {0} with value {1}", key, value));

                        f[key] = value;
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