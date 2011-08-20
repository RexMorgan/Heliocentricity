using StructureMap.Configuration.DSL;

namespace Heliocentricity.Configuration
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.WithDefaultConventions();
                     });
        }
    }
}