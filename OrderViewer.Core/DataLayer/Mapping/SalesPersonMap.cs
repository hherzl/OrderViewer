using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class SalesPersonMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesPerson>(builder =>
            {
                builder.ToTable("SalesPerson", "Sales");

                builder.HasKey(p => p.BusinessEntityID);
            });
        }
    }
}
