using System;
using Heliocentricity.Common.Logging;

namespace Heliocentricity.Logging
{
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine(string.Format("ERROR: {0}", message));
        }

        public void Warn(string message)
        {
            Console.WriteLine(string.Format("WARN: {0}", message));
        }

        public void Info(string message)
        {
            Console.WriteLine(string.Format("INFO: {0}", message));
        }

        public void Debug(string message)
        {
            Console.WriteLine(string.Format("DEBUG: {0}", message));
        }
    }
}