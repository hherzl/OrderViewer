using System;
using System.Collections.Generic;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Contracts
{
    public interface IProductionRepository : IRepository
    {
        IEnumerable<ProductSubcategory> GetProductSubcategories(Int32 pageSize, Int32 pageNumber);
    }
}
