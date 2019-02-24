using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class ProductSubcategoryMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSubcategory>(builder =>
            {
                builder.ToTable("ProductSubcategory", "Production");

                builder.HasKey(p => p.ProductSubcategoryID);

                builder.Property(p => p.ProductSubcategoryID).UseSqlServerIdentityColumn();
            });
        }
    }
}
