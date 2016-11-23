using System;
using System.Collections.Generic;
using OrderViewer.ViewModels;

namespace OrderViewer.Models
{
    public interface ISalesRepository : IDisposable
    {
        IEnumerable<OrderSummaryViewModel> GetOrders(Int32 pageSize, Int32 pageNumber, String salesOrderNumber, String customerName);

        OrderHeaderViewModel GetOrder(Int32 orderID);
    }
}
