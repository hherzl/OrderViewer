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
            var entity = modelBuilder.Entity<SalesOrderDetail>();

            entity.ToTable("SalesOrderDetail", "Sales");

            entity.HasKey(p => new { p.SalesOrderID, p.SalesOrderDetailID });

            entity.Property(p => p.SalesOrderDetailID).UseSqlServerIdentityColumn();
        }
    }
}
