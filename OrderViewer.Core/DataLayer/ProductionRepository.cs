using System;
using System.Collections.Generic;
using System.Linq;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.DataContracts;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer
{
    public class ProductionRepository : Repository, IProductionRepository
    {
        public ProductionRepository(AdventureWorksDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<ProductSubcategoryViewModel> GetProductSubcategories(Int32 pageSize, Int32 pageNumber)
        {
            var query =
                from productSubcategory in DbContext.Set<ProductSubcategory>()
                select new ProductSubcategoryViewModel
                {
                    ProductSubcategoryID = productSubcategory.ProductSubcategoryID,
                    ProductCategoryID = productSubcategory.ProductCategoryID,
                    Name = productSubcategory.Name,
                    ModifiedDate = productSubcategory.ModifiedDate
                };

            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }
    }
}
