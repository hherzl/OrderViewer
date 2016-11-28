using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrderViewer.Models
{
    public interface IEntityMapper
    {
        IEnumerable<IEntityMap> Mappings { get; }

        void MapEntities(ModelBuilder modelBuilder);
    }

    public class EntityMapper : IEntityMapper
    {
        public IEnumerable<IEntityMap> Mappings { get; protected set; }

        public void MapEntities(ModelBuilder modelBuilder)
        {
            foreach (var item in Mappings)
            {
                item.Map(modelBuilder);
            }
        }
    }

    public class AdventureWorksEntityMapper : EntityMapper
    {
        public AdventureWorksEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new SalesOrderHeaderMap() as IEntityMap,
                new AddressMap() as IEntityMap,
                new ShipMethodMap() as IEntityMap,
                new CustomerMap() as IEntityMap,
                new PersonMap() as IEntityMap,
                new StoreMap() as IEntityMap,
                new SalesPersonMap() as IEntityMap,
                new SalesTerritoryMap() as IEntityMap,
                new SalesOrderDetailMap() as IEntityMap,
                new ProductMap() as IEntityMap
            };
        }
    }

    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }

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

    public class SalesOrderDetailMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesOrderDetail>();

            entity.ToTable("SalesOrderDetail", "Sales");

            entity.HasKey(p => new { p.SalesOrderID, p.SalesOrderDetailID });

            entity.Property(p => p.SalesOrderDetailID).UseSqlServerIdentityColumn();
        }
    }

    public class CustomerMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();

            entity.ToTable("Customer", "Sales");

            entity.HasKey(p => p.CustomerID);

            entity.Property(p => p.CustomerID).UseSqlServerIdentityColumn();
        }
    }

    public class PersonMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Person>();

            entity.ToTable("Person", "Person");

            entity.HasKey(p => p.BusinessEntityID);
        }
    }

    public class StoreMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Store>();

            entity.ToTable("Store", "Sales");

            entity.HasKey(p => p.BusinessEntityID);
        }
    }

    public class SalesPersonMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SalesPerson>();

            entity.ToTable("SalesPerson", "Sales");

            entity.HasKey(p => p.BusinessEntityID);
        }
    }

    public class ProductMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Product>();

            entity.ToTable("Product", "Production");

            entity.HasKey(p => p.ProductID);

            entity.Property(p => p.ProductID).UseSqlServerIdentityColumn();
        }
    }

    public class AddressMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Address>();

            entity.ToTable("Address", "Person");

            entity.HasKey(p => p.AddressID);

            entity.Property(p => p.AddressID).UseSqlServerIdentityColumn();
        }
    }

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
