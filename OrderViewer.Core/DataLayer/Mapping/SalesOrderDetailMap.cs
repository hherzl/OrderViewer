using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class SalesOrderDetailMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderDetail>(builder =>
            {
                builder.ToTable("SalesOrderDetail", "Sales");

                builder.HasKey(p => new { p.SalesOrderID, p.SalesOrderDetailID });

                builder.Property(p => p.SalesOrderDetailID).UseSqlServerIdentityColumn();
            });
        }
    }
}
