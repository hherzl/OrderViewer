using System;
using System.Collections.Generic;
using OrderViewer.Core.DataLayer.DataContracts;

namespace OrderViewer.Core.DataLayer.Contracts
{
    public interface IProductionRepository : IDisposable
    {
        IEnumerable<ProductSubcategoryViewModel> GetProductSubcategories(Int32 pageSize, Int32 pageNumber);
    }
}
