using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
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
}
