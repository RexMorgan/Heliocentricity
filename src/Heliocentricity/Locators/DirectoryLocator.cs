using System.Collections.Generic;
using System.IO;
using System.Linq;
using Heliocentricity.Common.Locators;

namespace Heliocentricity.Locators
{
    public class DirectoryLocator : IDirectoryLocator
    {
        public IEnumerable<string> Directories(RunnerOptions options)
        {
            return Directory
                .GetDirectories(options.WorkingDirectory, "_*")
                .Where(x => !Path.GetFileName(x).Equals("_templates"))
                .ToList();
        }
    }
}