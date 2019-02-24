﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.DataContracts;
using OrderViewer.Core.EntityLayer;

namespace OrderViewer.Core.DataLayer.Repositories
{
    public class SalesRepository : Repository, ISalesRepository
    {
        public SalesRepository(AdventureWorksDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<OrderSummary> GetOrders(String salesOrderNumber, String customerName)
        {
            var query =
                from orderHeader in DbContext.Set<SalesOrderHeader>()
                join customer in DbContext.Set<Customer>()
                    on orderHeader.CustomerID equals customer.CustomerID
                join customerPersonJoin in DbContext.Set<Person>()
                    on customer.PersonID equals customerPersonJoin.BusinessEntityID
                        into customerPersonTemp
                from customerPerson in customerPersonTemp.Where(relation => relation.BusinessEntityID == customer.PersonID).DefaultIfEmpty()
                join customerStoreJoin in DbContext.Set<Store>()
                    on customer.StoreID equals customerStoreJoin.BusinessEntityID
                        into customerStoreTemp
                from customerStore in customerStoreTemp.Where(relation => relation.BusinessEntityID == customer.StoreID).DefaultIfEmpty()
                select new OrderSummary
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

            return query;
        }

        public Task<SalesOrderHeader> GetOrderAsync(Int32 orderID)
        {
            var entity = DbContext
                .Set<SalesOrderHeader>()
                .Include(p => p.CustomerFk.PersonFk)
                .Include(p => p.CustomerFk.StoreFk)
                // todo: fix navigation property
                //.Include(p => p.SalesPersonFk)
                .Include(p => p.SalesTerritoryFk)
                .Include(p => p.ShipMethodFk)
                .Include(p => p.BillAddressFk)
                .Include(p => p.ShipAddressFk)
                .Include(p => p.SalesOrderDetails)
                    .ThenInclude(p => p.ProductFk)
                .FirstOrDefaultAsync(item => item.SalesOrderID == orderID);

            return entity;
        }
    }
}
