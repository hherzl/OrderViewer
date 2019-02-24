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
            modelBuilder.Entity<SalesTerritory>(builder =>
            {
                builder.ToTable("SalesTerritory", "Sales");

                builder.HasKey(p => p.TerritoryID);

                builder.Property(p => p.TerritoryID).UseSqlServerIdentityColumn();
            });
        }
    }
}
