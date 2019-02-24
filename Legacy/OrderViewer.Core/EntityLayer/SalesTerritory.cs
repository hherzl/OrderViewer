using System;

namespace OrderViewer.Core.EntityLayer
{
    public class SalesTerritory
    {
        public Int32? TerritoryID { get; set; }

        public String Name { get; set; }

        public String CountryRegionCode { get; set; }

        public String Group { get; set; }

        public Decimal? SalesYTD { get; set; }

        public Decimal? SalesLastYear { get; set; }

        public Decimal? CostYTD { get; set; }

        public Decimal? CostLastYear { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
