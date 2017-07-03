using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class SalesTerritoryMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesTerritory>();

            entity.ToTable("SalesTerritory", "Sales");

            entity.HasKey(p => p.TerritoryID);

            entity.Property(p => p.TerritoryID).UseSqlServerIdentityColumn();
        }
    }
}
