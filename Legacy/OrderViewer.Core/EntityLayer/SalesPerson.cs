using System;

namespace OrderViewer.Core.EntityLayer
{
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

        public virtual Person PersonFk { get; set; }
    }
}
