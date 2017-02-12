using System;
using System.Collections.Generic;
using System.Linq;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.ViewModels
{
    public class OrderHeaderViewModel
    {
        public OrderHeaderViewModel()
        {
        }

        public OrderHeaderViewModel(SalesOrderHeader entity)
        {
            SalesOrderID = entity.SalesOrderID;
            RevisionNumber = entity.RevisionNumber;
            OrderDate = entity.OrderDate;
            DueDate = entity.DueDate;
            ShipDate = entity.ShipDate;
            Status = entity.Status;
            OnlineOrderFlag = entity.OnlineOrderFlag;
            SalesOrderNumber = entity.SalesOrderNumber;
            PurchaseOrderNumber = entity.PurchaseOrderNumber;
            AccountNumber = entity.AccountNumber;
            CustomerName = entity.CustomerFk?.PersonFk?.FirstName + (entity.CustomerFk.PersonFk?.MiddleName == null ? String.Empty : " " + entity.CustomerFk?.PersonFk?.MiddleName) + " " + entity.CustomerFk?.PersonFk?.LastName;
            StoreName = entity.CustomerFk?.StoreFk?.Name;
            SalesPersonName = entity.SalesPersonFk == null ? String.Empty : entity.SalesPersonFk.PersonFk?.FirstName + (entity.SalesPersonFk.PersonFk?.MiddleName == null ? String.Empty : " " + entity.SalesPersonFk.PersonFk?.MiddleName) + " " + entity.SalesPersonFk.PersonFk?.LastName;
            TerritoryName = entity.SalesTerritoryFk.Name;
            ShipMethodName = entity.ShipMethodFk.Name;
            CurrencyRateID = entity.CurrencyRateID;
            SubTotal = entity.SubTotal;
            TaxAmt = entity.TaxAmt;
            Freight = entity.Freight;
            TotalDue = entity.TotalDue;
            Comment = entity.Comment;
            ModifiedDate = entity.ModifiedDate;
        }

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

        public String CustomerName { get; set; }

        public String StoreName { get; set; }

        public String SalesPersonName { get; set; }

        public String TerritoryName { get; set; }

        public String ShipMethodName { get; set; }

        public Int32? CurrencyRateID { get; set; }

        public Decimal? SubTotal { get; set; }

        public Decimal? TaxAmt { get; set; }

        public Decimal? Freight { get; set; }

        public Decimal? TotalDue { get; set; }

        public String Comment { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public AddressViewModel BillAddress { get; set; }

        public AddressViewModel ShipAddress { get; set; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }

        public Decimal? Total
        {
            get
            {
                return OrderDetails == null ? 0 : OrderDetails.Sum(item => item.LineTotal);
            }
        }
    }
}
