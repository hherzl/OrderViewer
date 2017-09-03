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
        {
            //Int32 pageSize, Int32 pageNumber
            //Int32 pageSize, Int32 pageNumber

            return from productSubcategory in DbContext.Set<ProductSubcategory>()
                   select productSubcategory;

            //return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }
    }
}
