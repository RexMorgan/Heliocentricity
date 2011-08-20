using System;
using Heliocentricity.Common;
using Heliocentricity.Configuration;
using StructureMap;

namespace Heliocentricity
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(x => x.IncludeRegistry<CoreRegistry>());
            
            var runner = container.GetInstance<IRunner>();

            var options = new RunnerOptions
                              {
                                  WorkingDirectory = Environment.CurrentDirectory
                              };

            runner.Run(options);
        }
    }
}
