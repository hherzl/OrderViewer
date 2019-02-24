using System;

namespace OrderViewer.Core.EntityLayer
{
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
}
