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

            entity.HasOne(p => p.BillAddressFk).WithMany(p => p.BillingOrders).HasForeignKey(p => p.BillToAddressID);

            entity.HasOne(p => p.ShipAddressFk).WithMany(p => p.ShippingOrders).HasForeignKey(p => p.ShipToAddressID);

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

        public static ModelBuilder MapAddress(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Address>();

            entity.ToTable("Address", "Person");

            entity.HasKey(p => p.AddressID);

            entity.Property(p => p.AddressID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }

        public static ModelBuilder MapShipMethod(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ShipMethod>();

            entity.ToTable("ShipMethod", "Purchasing");

            entity.HasKey(p => p.ShipMethodID);

            entity.Property(p => p.ShipMethodID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }

        public static ModelBuilder MapSalesTerritory(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesTerritory>();

            entity.ToTable("SalesTerritory", "Sales");

            entity.HasKey(p => p.TerritoryID);

            entity.Property(p => p.TerritoryID).UseSqlServerIdentityColumn();

            return modelBuilder;
        }
    }
}
