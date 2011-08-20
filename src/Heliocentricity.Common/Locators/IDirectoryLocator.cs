using System.Collections.Generic;

namespace Heliocentricity.Common.Locators
{
    public interface IDirectoryLocator
    {
        IEnumerable<string> Directories(RunnerOptions options);
    }
}