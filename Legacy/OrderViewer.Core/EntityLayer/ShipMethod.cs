using System;

namespace OrderViewer.Core.EntityLayer
{
    public class ShipMethod
    {
        public Int32? ShipMethodID { get; set; }

        public String Name { get; set; }

        public Decimal? ShipBase { get; set; }

        public Decimal? ShipRate { get; set; }

        public Guid? Rowguid { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
