using System;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.ViewModels
{
    public class OrderDetailViewModel
    {
        public OrderDetailViewModel()
        {
        }

        public OrderDetailViewModel(SalesOrderDetail entity)
        {
            SalesOrderID = entity.SalesOrderID;
            SalesOrderDetailID = entity.SalesOrderDetailID;
            CarrierTrackingNumber = entity.CarrierTrackingNumber;
            OrderQty = entity.OrderQty;
            ProductID = entity.ProductID;
            ProductName = entity.ProductFk.Name;
            SpecialOfferID = entity.SpecialOfferID;
            UnitPrice = entity.UnitPrice;
            UnitPriceDiscount = entity.UnitPriceDiscount;
            LineTotal = entity.LineTotal;
            ModifiedDate = entity.ModifiedDate;
        }

        public Int32? SalesOrderID { get; set; }

        public Int32? SalesOrderDetailID { get; set; }

        public String CarrierTrackingNumber { get; set; }

        public Int16? OrderQty { get; set; }

        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public Int32? SpecialOfferID { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Decimal? UnitPriceDiscount { get; set; }

        public Decimal? LineTotal { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
