using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.DataContracts;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer
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

        public IEnumerable<OrderSummaryViewModel> GetOrders(Int32 pageSize, Int32 pageNumber, String salesOrderNumber, String customerName)
        {
            var query =
                from orderHeader in DbContext.Set<SalesOrderHeader>()
                join customer in DbContext.Set<Customer>()
                    on orderHeader.CustomerID equals customer.CustomerID
                join customerPersonJoin in DbContext.Set<Person>()
                    on customer.PersonID equals customerPersonJoin.BusinessEntityID
                        into customerPersonTemp from customerPerson in customerPersonTemp.Where(relation => relation.BusinessEntityID == customer.PersonID).DefaultIfEmpty()
                join customerStoreJoin in DbContext.Set<Store>()
                    on customer.StoreID equals customerStoreJoin.BusinessEntityID
                        into customerStoreTemp from customerStore in customerStoreTemp.Where(relation => relation.BusinessEntityID == customer.StoreID).DefaultIfEmpty()
                select new OrderSummaryViewModel
                {
                    SalesOrderID = orderHeader.SalesOrderID,
                    OrderDate = orderHeader.OrderDate,
                    DueDate = orderHeader.DueDate,
                    ShipDate = orderHeader.ShipDate,
                    SalesOrderNumber = orderHeader.SalesOrderNumber,
                    CustomerID = orderHeader.CustomerID,
                    CustomerName = customerPerson.FirstName + (customerPerson.MiddleName == null ? String.Empty : " " + customerPerson.MiddleName) + " " + customerPerson.LastName,
                    StoreName = customerStore == null ? String.Empty : customerStore.Name,
                    Lines = orderHeader.SalesOrderDetails.Count(),
                    TotalDue = orderHeader.TotalDue
                };

            if (!String.IsNullOrEmpty(salesOrderNumber))
            {
                query = query.Where(item => item.SalesOrderNumber.ToLower().Contains(salesOrderNumber.ToLower()));
            }

            if (!String.IsNullOrEmpty(customerName))
            {
                query = query.Where(item => item.CustomerName.ToLower().Contains(customerName.ToLower()));
            }

            if (String.IsNullOrEmpty(salesOrderNumber) && String.IsNullOrEmpty(customerName))
            {
                query = query.OrderByDescending(item => item.SalesOrderID);
            }

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public OrderHeaderViewModel GetOrder(Int32 orderID)
        {
            var entity = DbContext
                .Set<SalesOrderHeader>()
                .Include(p => p.CustomerFk.PersonFk)
                .Include(p => p.CustomerFk.StoreFk)
                .Include(p => p.SalesPersonFk)
                .Include(p => p.SalesTerritoryFk)
                .Include(p => p.ShipMethodFk)
                .Include(p => p.BillAddressFk)
                .Include(p => p.ShipAddressFk)
                .Include(p => p.SalesOrderDetails)
                    .ThenInclude(p => p.ProductFk)
                .FirstOrDefault(item => item.SalesOrderID == orderID);

            return entity == null ? null : new OrderHeaderViewModel(entity)
            {
                BillAddress = new AddressViewModel(entity.BillAddressFk),
                ShipAddress = new AddressViewModel(entity.ShipAddressFk),
                OrderDetails = new List<OrderDetailViewModel>(entity.SalesOrderDetails.Select(item => new OrderDetailViewModel(item)))
            };
        }
    }
}
