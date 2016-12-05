using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
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
}
