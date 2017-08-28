using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class ShipMethodMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipMethod>(builder =>
            {
                builder.ToTable("ShipMethod", "Purchasing");

                builder.HasKey(p => p.ShipMethodID);

                builder.Property(p => p.ShipMethodID).UseSqlServerIdentityColumn();
            });
        }
    }
}
