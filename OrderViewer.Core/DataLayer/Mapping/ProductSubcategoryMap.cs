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
            var entity = modelBuilder.Entity<ProductSubcategory>();

            entity.ToTable("ProductSubcategory", "Production");

            entity.HasKey(p => p.ProductSubcategoryID);

            entity.Property(p => p.ProductSubcategoryID).UseSqlServerIdentityColumn();
        }
    }
}
