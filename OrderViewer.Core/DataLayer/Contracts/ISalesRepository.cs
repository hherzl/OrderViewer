using System;
using System.Linq;
using System.Threading.Tasks;
using OrderViewer.Core.DataLayer.DataContracts;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Contracts
{
    public interface ISalesRepository : IRepository
    {
        IQueryable<OrderSummary> GetOrders(Int32 pageSize, Int32 pageNumber, String salesOrderNumber, String customerName);

        Task<SalesOrderHeader> GetOrderAsync(Int32 orderID);
    }
}
