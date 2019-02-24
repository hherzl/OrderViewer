using Microsoft.EntityFrameworkCore;

namespace OrderViewer.Core.DataLayer.Mapping
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
