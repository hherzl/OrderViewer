using System;

namespace OrderViewer.Core.DataLayer.DataContracts
{
    public class OrderSummary
    {
        public Int32? SalesOrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ShipDate { get; set; }

        public String SalesOrderNumber { get; set; }

        public Int32? CustomerID { get; set; }

        public String CustomerName { get; set; }

        public String StoreName { get; set; }

        public Int32 Lines { get; set; }

        public Decimal? TotalDue { get; set; }
    }
}
