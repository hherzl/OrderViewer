using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.DataLayer.Mapping;

namespace OrderViewer.Core.DataLayer
{
    public class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options, IEntityMapper entityMapper)
            : base(options)
        {
            EntityMapper = entityMapper;
        }

        public IEntityMapper EntityMapper { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load all mappings for entities
            EntityMapper.MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
