using System;
using System.Collections.ObjectModel;

namespace OrderViewer.Core.EntityLayer
{
    public class Address
    {
        public Int32? AddressID { get; set; }

        public String AddressLine1 { get; set; }

        public String AddressLine2 { get; set; }

        public String City { get; set; }

        public Int32? StateProvinceID { get; set; }

        public String PostalCode { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Collection<SalesOrderHeader> BillingOrders { get; set; }

        public virtual Collection<SalesOrderHeader> ShippingOrders { get; set; }
    }
}
