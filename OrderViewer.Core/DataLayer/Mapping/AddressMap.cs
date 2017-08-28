using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class AddressMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(builder =>
            {
                builder.ToTable("Address", "Person");

                builder.HasKey(p => p.AddressID);

                builder.Property(p => p.AddressID).UseSqlServerIdentityColumn();
            });
        }
    }
}
