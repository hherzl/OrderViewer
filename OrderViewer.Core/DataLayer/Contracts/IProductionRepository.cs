using System;
using System.Linq;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Contracts
{
    public interface IProductionRepository : IRepository
    {
        IQueryable<ProductSubcategory> GetProductSubcategories(Int32 pageSize, Int32 pageNumber);
    }
}
