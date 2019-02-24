using System;

namespace OrderViewer.Core.EntityLayer
{
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
}
