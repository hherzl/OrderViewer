using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace OrderViewer.Models
{
    public class AdventureWorksDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AdventureWorksDbContext(IOptions<AppSettings> appSettings)
        {
            ConnectionString = appSettings.Value.ConnectionString;
        }

        public String ConnectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .MapSalesOrderHeader()
                .MapAddress()
                .MapShipMethod()
                .MapCustomer()
                .MapPerson()
                .MapStore()
                .MapSalesPerson()
                .MapSalesTerritory()
                .MapSalesOrderDetail()
                .MapProduct();

            base.OnModelCreating(modelBuilder);
        }
    }
}
