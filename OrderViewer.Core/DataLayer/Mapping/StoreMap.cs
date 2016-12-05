using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
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
