using System;
using System.Collections.Generic;
using OrderViewer.Core.DataLayer.DataContracts;

namespace OrderViewer.Core.DataLayer.Contracts
{
    public interface ISalesRepository : IDisposable
    {
        IEnumerable<OrderSummaryViewModel> GetOrders(Int32 pageSize, Int32 pageNumber, String salesOrderNumber, String customerName);

        OrderHeaderViewModel GetOrder(Int32 orderID);
    }
}
