using System.Collections.Generic;
using System.Linq;
using OrderViewer.Core.EntityLayer;
using OrderViewer.ViewModels;

namespace OrderViewer.Extensions
{
    public static class OrderHeaderMapper
    {
        public static OrderHeaderViewModel ToViewModel(this SalesOrderHeader entity)
        {
            return entity == null ? null : new OrderHeaderViewModel(entity)
            {
                BillAddress = new AddressViewModel(entity.BillAddressFk),
                ShipAddress = new AddressViewModel(entity.ShipAddressFk),
                OrderDetails = new List<OrderDetailViewModel>(entity.SalesOrderDetails.Select(item => new OrderDetailViewModel(item)))
            };
        }
    }
}
