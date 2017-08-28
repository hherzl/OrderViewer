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
            modelBuilder.Entity<SalesOrderHeader>(builder =>
            {
                builder.ToTable("SalesOrderHeader", "Sales");

                builder.HasKey(p => p.SalesOrderID);

                builder.Property(p => p.SalesOrderID).UseSqlServerIdentityColumn();

                builder.HasOne(p => p.BillAddressFk).WithMany(p => p.BillingOrders).HasForeignKey(p => p.BillToAddressID);

                builder.HasOne(p => p.ShipAddressFk).WithMany(p => p.ShippingOrders).HasForeignKey(p => p.ShipToAddressID);
            });
        }
    }
}
