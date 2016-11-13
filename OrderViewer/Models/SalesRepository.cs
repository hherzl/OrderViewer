using System;
using System.Collections.Generic;
using System.Linq;
using OrderViewer.ViewModels;

namespace OrderViewer.Models
{
    public class SalesRepository : ISalesRepository
    {
        private readonly AdventureWorksDbContext DbContext;
        private Boolean Disposed;

        public SalesRepository(AdventureWorksDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }

        public IEnumerable<OrderSummaryViewModel> GetOrders(Int32 pageSize, Int32 pageNumber)
        {
            var query = from orderHeader in DbContext.Set<SalesOrderHeader>()
                        select new OrderSummaryViewModel
                        {
                            SalesOrderID = orderHeader.SalesOrderID,
                            OrderDate = orderHeader.OrderDate,
                            DueDate = orderHeader.DueDate,
                            ShipDate = orderHeader.ShipDate,
                            SalesOrderNumber = orderHeader.SalesOrderNumber,
                            Lines = orderHeader.SalesOrderDetails.Count()
                        };

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
