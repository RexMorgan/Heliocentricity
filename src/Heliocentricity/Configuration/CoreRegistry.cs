using StructureMap.Configuration.DSL;

namespace Heliocentricity.Configuration
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.LookForRegistries();
                     });
        }
    }
}