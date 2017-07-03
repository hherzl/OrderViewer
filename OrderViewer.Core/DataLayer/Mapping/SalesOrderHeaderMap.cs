using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class SalesOrderHeaderMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesOrderHeader>();

            entity.ToTable("SalesOrderHeader", "Sales");

            entity.HasKey(p => p.SalesOrderID);

            entity.Property(p => p.SalesOrderID).UseSqlServerIdentityColumn();

            entity.HasOne(p => p.BillAddressFk).WithMany(p => p.BillingOrders).HasForeignKey(p => p.BillToAddressID);

            entity.HasOne(p => p.ShipAddressFk).WithMany(p => p.ShippingOrders).HasForeignKey(p => p.ShipToAddressID);
        }
    }
}
