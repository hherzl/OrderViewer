using System;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel(Address entity)
        {
            AddressID = entity.AddressID;
            AddressLine1 = entity.AddressLine1;
            AddressLine2 = entity.AddressLine2;
            City = entity.City;
            StateProvinceID = entity.StateProvinceID;
            PostalCode = entity.PostalCode;
        }

        public Int32? AddressID { get; set; }

        public String AddressLine1 { get; set; }

        public String AddressLine2 { get; set; }

        public String City { get; set; }

        public Int32? StateProvinceID { get; set; }

        public String PostalCode { get; set; }
    }
}
