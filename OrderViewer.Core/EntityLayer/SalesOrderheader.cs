using System;
using System.Collections.ObjectModel;

namespace OrderViewer.Core.EntityLayer
{
    public class SalesOrderHeader
    {
        public Int32? SalesOrderID { get; set; }

        public Byte? RevisionNumber { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ShipDate { get; set; }

        public Byte? Status { get; set; }

        public Boolean? OnlineOrderFlag { get; set; }

        public String SalesOrderNumber { get; set; }

        public String PurchaseOrderNumber { get; set; }

        public String AccountNumber { get; set; }

        public Int32? CustomerID { get; set; }

        public Int32? SalesPersonID { get; set; }

        public Int32? TerritoryID { get; set; }

        public Int32? BillToAddressID { get; set; }

        public Int32? ShipToAddressID { get; set; }

        public Int32? ShipMethodID { get; set; }

        public Int32? CreditCardID { get; set; }

        public String CreditCardApprovalCode { get; set; }

        public Int32? CurrencyRateID { get; set; }

        public Decimal? SubTotal { get; set; }

        public Decimal? TaxAmt { get; set; }

        public Decimal? Freight { get; set; }

        public Decimal? TotalDue { get; set; }

        public String Comment { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Customer CustomerFk { get; set; }

        public virtual SalesPerson SalesPersonFk { get; set; }

        public virtual SalesTerritory SalesTerritoryFk { get; set; }

        public virtual Address BillAddressFk { get; set; }

        public virtual Address ShipAddressFk { get; set; }

        public virtual ShipMethod ShipMethodFk { get; set; }

        public virtual Collection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
