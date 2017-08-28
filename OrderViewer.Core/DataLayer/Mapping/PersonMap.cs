using System.Composition;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class PersonMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(builder =>
            {
                builder.ToTable("Person", "Person");

                builder.HasKey(p => p.BusinessEntityID);
            });
        }
    }
}
