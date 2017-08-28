using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class CustomerMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.ToTable("Customer", "Sales");

                builder.HasKey(p => p.CustomerID);

                builder.Property(p => p.CustomerID).UseSqlServerIdentityColumn();
            });
        }
    }
}
