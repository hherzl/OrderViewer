using System.Composition;
using Microsoft.EntityFrameworkCore;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class StoreMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Store>();

            entity.ToTable("Store", "Sales");

            entity.HasKey(p => p.BusinessEntityID);
        }
    }
}
