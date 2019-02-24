using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class ProductMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("Product", "Production");

                builder.HasKey(p => p.ProductID);

                builder.Property(p => p.ProductID).UseSqlServerIdentityColumn();
            });
        }
    }
}
