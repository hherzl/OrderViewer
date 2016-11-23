using System;
using System.Collections.Generic;
using OrderViewer.Models;

namespace OrderViewer.ViewModels
{
    public class OrderHeaderViewModel
    {
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
            CustomerID = entity.CustomerID;
            if (entity.CustomerFk != null)
            {
                CustomerName = entity.CustomerFk.PersonFk.FirstName + (entity.CustomerFk.PersonFk.MiddleName == null ? String.Empty : " " + entity.CustomerFk.PersonFk.MiddleName + " ") + " " + entity.CustomerFk.PersonFk.LastName + (entity.CustomerFk.StoreFk == null ? String.Empty : " (" + entity.CustomerFk.StoreFk.Name + ")");
            }
            SalesPersonID = entity.SalesPersonID;
            SalesPersonName = "";
            TerritoryID = entity.TerritoryID;
            BillToAddressID = entity.BillToAddressID;
            ShipToAddressID = entity.ShipToAddressID;
            ShipMethodID = entity.ShipMethodID;
            CreditCardID = entity.CreditCardID;
            CreditCardApprovalCode = entity.CreditCardApprovalCode;
            CurrencyRateID = entity.CurrencyRateID;
            SubTotal = entity.CurrencyRateID;
            TaxAmt = entity.TaxAmt;
            Freight = entity.Freight;
            TotalDue = entity.TotalDue;
            Comment = entity.Comment;
            Rowguid = entity.Rowguid;
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

        public Int32? CustomerID { get; set; }

        public String CustomerName { get; set; }

        public Int32? SalesPersonID { get; set; }

        public String SalesPersonName { get; set; }

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

        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
