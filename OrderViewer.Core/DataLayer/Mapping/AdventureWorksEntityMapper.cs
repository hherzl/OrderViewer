using System.Composition.Hosting;
using System.Reflection;

namespace OrderViewer.Core.DataLayer.Mapping
{
    public class AdventureWorksEntityMapper : EntityMapper
    {
        public AdventureWorksEntityMapper()
        {
            // Get current assembly
            var assemblies = new[] { typeof(AdventureWorksDbContext).GetTypeInfo().Assembly };

            // Get configuration for container from current assembly
            var configuration = new ContainerConfiguration().WithAssembly(typeof(AdventureWorksDbContext).GetTypeInfo().Assembly);

            // Create container for exports
            using (var container = configuration.CreateContainer())
            {
                // Get all definitions that implement IEntityMap interface
                Mappings = container.GetExports<IEntityMap>();
            }
        }
    }
}
