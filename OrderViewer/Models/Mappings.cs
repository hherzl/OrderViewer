using Microsoft.EntityFrameworkCore;

namespace OrderViewer.Models
{
    public static class Mappings
    {
        public static ModelBuilder MapSalesOrderHeader(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesOrderHeader>();

            entity.ToTable("SalesOrderHeader", "Sales");

            entity.HasKey(p => new { p.SalesOrderID });

            entity.Property(p => p.SalesOrderID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }

        public static ModelBuilder MapSalesOrderDetail(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesOrderDetail>();

            entity.ToTable("SalesOrderDetail", "Sales");

            entity.HasKey(p => new { p.SalesOrderID, p.SalesOrderDetailID });

            entity.Property(p => p.SalesOrderDetailID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }
    }
}
