using System.Composition.Hosting;
using System.Reflection;

namespace OrderViewer.Core.DataLayer.Mapping
{
    public class AdventureWorksEntityMapper : EntityMapper
    {
        public AdventureWorksEntityMapper()
        {
            var assemblies = new[] { typeof(AdventureWorksDbContext).GetTypeInfo().Assembly };

            var configuration = new ContainerConfiguration().WithAssembly(typeof(AdventureWorksDbContext).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                Mappings = container.GetExports<IEntityMap>();
            }
        }
    }
}
