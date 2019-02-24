using System;

namespace OrderViewer.Core.EntityLayer
{
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
}
