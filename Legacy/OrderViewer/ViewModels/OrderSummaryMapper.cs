using OrderViewer.Core.DataLayer.DataContracts;

namespace OrderViewer.ViewModels
{
    public static class OrderSummaryMapper
    {
        public static OrderSummaryViewModel ToViewModel(this OrderSummary entity)
        {
            return new OrderSummaryViewModel
            {
                SalesOrderID = entity.SalesOrderID,
                OrderDate = entity.OrderDate,
                DueDate = entity.DueDate,
                ShipDate = entity.ShipDate,
                SalesOrderNumber = entity.SalesOrderNumber,
                CustomerID = entity.CustomerID,
                CustomerName = entity.CustomerName,
                StoreName = entity.StoreName,
                Lines = entity.Lines,
                TotalDue = entity.TotalDue
            };
        }
    }
}
