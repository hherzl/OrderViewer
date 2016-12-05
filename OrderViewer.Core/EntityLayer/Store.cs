using System;

namespace OrderViewer.Core
{
    public class Store
    {
        public Int32? BusinessEntityID { get; set; }

        public String Name { get; set; }

        public Int32? SalesPersonID { get; set; }

        public String Demographics { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
