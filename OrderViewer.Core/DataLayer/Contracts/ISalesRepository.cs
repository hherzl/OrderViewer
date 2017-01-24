using System;
using System.Collections.Generic;
using OrderViewer.Core.DataLayer.DataContracts;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Contracts
{
    public interface ISalesRepository : IRepository
    {
        IEnumerable<OrderSummary> GetOrders(Int32 pageSize, Int32 pageNumber, String salesOrderNumber, String customerName);

        SalesOrderHeader GetOrder(Int32 orderID);
    }
}
