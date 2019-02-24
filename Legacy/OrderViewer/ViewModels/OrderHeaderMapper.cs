using System.Collections.Generic;
using System.Linq;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.ViewModels
{
    public static class OrderHeaderMapper
    {
        public static OrderHeaderViewModel ToViewModel(this SalesOrderHeader entity)
        {
            return new OrderHeaderViewModel(entity)
            {
                BillAddress = new AddressViewModel(entity.BillAddressFk),
                ShipAddress = new AddressViewModel(entity.ShipAddressFk),
                OrderDetails = new List<OrderDetailViewModel>(entity.SalesOrderDetails.Select(item => new OrderDetailViewModel(item)))
            };
        }
    }
}
