using Microsoft.EntityFrameworkCore;

namespace OrderViewer.Models
{
    public static class Mappings
    {
        public static ModelBuilder MapSalesOrderHeader(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesOrderHeader>();

            entity.ToTable("SalesOrderHeader", "Sales");

            entity.HasKey(p => p.SalesOrderID);

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

        public static ModelBuilder MapCustomer(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();

            entity.ToTable("Customer", "Sales");

            entity.HasKey(p => p.CustomerID);

            entity.Property(p => p.CustomerID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }

        public static ModelBuilder MapPerson(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Person>();

            entity.ToTable("Person", "Person");

            entity.HasKey(p => p.BusinessEntityID);

            return modelBuilder;
        }

        public static ModelBuilder MapStore(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Store>();

            entity.ToTable("Store", "Sales");

            entity.HasKey(p => p.BusinessEntityID);

            return modelBuilder;
        }

        public static ModelBuilder MapSalesPerson(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesPerson>();

            entity.ToTable("SalesPerson", "Sales");

            entity.HasKey(p => p.BusinessEntityID);

            return modelBuilder;
        }

        public static ModelBuilder MapProduct(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Product>();

            entity.ToTable("Product", "Production");

            entity.HasKey(p => p.ProductID);

            entity.Property(p => p.ProductID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }
    }
}
