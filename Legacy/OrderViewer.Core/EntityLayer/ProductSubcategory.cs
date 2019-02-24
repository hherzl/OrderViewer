using System;

namespace OrderViewer.Core.EntityLayer
{
    public class ProductSubcategory
    {
        public Int32? ProductSubcategoryID { get; set; }

        public Int32? ProductCategoryID { get; set; }

        public String Name { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
