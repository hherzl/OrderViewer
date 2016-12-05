using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    public class ShipMethodMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ShipMethod>();

            entity.ToTable("ShipMethod", "Purchasing");

            entity.HasKey(p => p.ShipMethodID);

            entity.Property(p => p.ShipMethodID).UseSqlServerIdentityColumn();
        }
    }
}
