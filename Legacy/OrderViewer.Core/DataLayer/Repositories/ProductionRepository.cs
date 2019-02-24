using System.Linq;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Repositories
{
    public class ProductionRepository : Repository, IProductionRepository
    {
        public ProductionRepository(AdventureWorksDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<ProductSubcategory> GetProductSubcategories()
            => DbContext.Set<ProductSubcategory>();
    }
}
