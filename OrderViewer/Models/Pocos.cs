using System;
using System.Collections.ObjectModel;

namespace OrderViewer.Models
{
    public class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetails = new Collection<SalesOrderDetail>();
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

        public virtual Collection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }

    public class SalesOrderDetail
    {
        public Int32? SalesOrderID { get; set; }

        public Int32? SalesOrderDetailID { get; set; }

        public String CarrierTrackingNumber { get; set; }

        public Int16? OrderQty { get; set; }

        public Int32? ProductID { get; set; }

        public Int32? SpecialOfferID { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Decimal? UnitPriceDiscount { get; set; }

        public Decimal? LineTotal { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Product ProductFk { get; set; }
    }

    public class Customer
    {
        public Int32? CustomerID { get; set; }

        public Int32? PersonID { get; set; }

        public Int32? StoreID { get; set; }

        public Int32? TerritoryID { get; set; }

        public String AccountNumber { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Person PersonFk { get; set; }

        public virtual Store StoreFk { get; set; }
    }

    public class Person
    {
        public Int32? BusinessEntityID { get; set; }

        public String PersonType { get; set; }

        public Boolean? NameStyle { get; set; }

        public String Title { get; set; }

        public String FirstName { get; set; }

        public String MiddleName { get; set; }

        public String LastName { get; set; }

        public String Suffix { get; set; }

        public Int32? EmailPromotion { get; set; }

        public String AdditionalContactInfo { get; set; }

        public String Demographics { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }

    public class Store
    {
        public Int32? BusinessEntityID { get; set; }

        public String Name { get; set; }

        public Int32? SalesPersonID { get; set; }

        public String Demographics { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }

    public class SalesPerson
    {
        public Int32? BusinessEntityID { get; set; }

        public Int32? TerritoryID { get; set; }

        public Decimal? SalesQuota { get; set; }

        public Decimal? Bonus { get; set; }

        public Decimal? CommissionPct { get; set; }

        public Decimal? SalesYTD { get; set; }

        public Decimal? SalesLastYear { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }

    public class Product
    {
        public Int32? ProductID { get; set; }

        public String Name { get; set; }

        public String ProductNumber { get; set; }

        public Boolean? MakeFlag { get; set; }

        public Boolean? FinishedGoodsFlag { get; set; }

        public Int16? SafetyStockLevel { get; set; }

        public Int16? ReorderPoint { get; set; }

        public Decimal? StandardCost { get; set; }

        public Decimal? ListPrice { get; set; }

        public Int32? DaysToManufacture { get; set; }

        public DateTime? SellStartDate { get; set; }

        public Guid? rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
