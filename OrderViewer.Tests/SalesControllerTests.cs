using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrderViewer.Controllers;
using OrderViewer.Models;
using OrderViewer.Responses;
using OrderViewer.ViewModels;
using Xunit;

namespace Tests
{
    public class SalesControllerTests
    {
        private ISalesRepository SalesRepository
        {
            get
            {
                var appSettings = Options.Create(new AppSettings
                {
                    ConnectionString = "server=(local);database=AdventureWorks2012;integrated security=yes;"
                });

                return new SalesRepository(new AdventureWorksDbContext(appSettings)) as ISalesRepository;
            }
        }

        [Fact]
        public async Task TestGetOrders_Async()
        {
            // Arrange
            var controller = new SalesController(SalesRepository);

            // Act
            var response = await controller.GetOrders() as ObjectResult;

            // Assert
            var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestGetOrdersSearchingBySalesOrderNumber_Async()
        {
            // Arrange
            var controller = new SalesController(SalesRepository);

            var salesOrderNumber = "so72";

            // Act
            var response = await controller.GetOrders(salesOrderNumber: salesOrderNumber) as ObjectResult;

            // Assert
            var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestGetOrdersSearchingByCustomerName_Async()
        {
            // Arrange
            var controller = new SalesController(SalesRepository);

            var customerName = "her";

            // Act
            var response = await controller.GetOrders(customerName: customerName) as ObjectResult;

            // Assert
            var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestGetOrdersSearchingBySalesOrderNumberAndCustomerName_Async()
        {
            // Arrange
            var controller = new SalesController(SalesRepository);

            var salesOrderNumber = "so72";
            var customerName = "her";

            // Act
            var response = await controller.GetOrders(salesOrderNumber: salesOrderNumber, customerName: customerName) as ObjectResult;

            // Assert
            var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

            Assert.False(value.DidError);
        }
    }
}
