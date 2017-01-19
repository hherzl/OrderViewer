using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.Controllers;
using OrderViewer.Core.DataLayer.DataContracts;
using OrderViewer.Responses;
using Xunit;

namespace OrderViewer.Tests
{
    public class SalesControllerTests
    {
        [Fact]
        public async Task TestGetOrdersAsync()
        {
            using (var repository = RepositoryMocker.GetSalesRepository())
            {
                // Arrange
                var controller = new SalesController(repository);

                // Act
                var response = await controller.GetOrders() as ObjectResult;

                // Assert
                var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetOrdersSearchingBySalesOrderNumberAsync()
        {
            using (var repository = RepositoryMocker.GetSalesRepository())
            {
                // Arrange
                var controller = new SalesController(repository);
                var salesOrderNumber = "so72";

                // Act
                var response = await controller.GetOrders(salesOrderNumber: salesOrderNumber) as ObjectResult;

                // Assert
                var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetOrdersSearchingByCustomerNameAsync()
        {
            using (var repository = RepositoryMocker.GetSalesRepository())
            {
                // Arrange
                var controller = new SalesController(repository);
                var customerName = "her";

                // Act
                var response = await controller.GetOrders(customerName: customerName) as ObjectResult;

                // Assert
                var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetOrdersSearchingBySalesOrderNumberAndCustomerNameAsync()
        {
            using (var repository = RepositoryMocker.GetSalesRepository())
            {
                // Arrange
                var controller = new SalesController(repository);
                var salesOrderNumber = "so72";
                var customerName = "her";

                // Act
                var response = await controller.GetOrders(salesOrderNumber: salesOrderNumber, customerName: customerName) as ObjectResult;

                // Assert
                var value = response.Value as IListModelResponse<OrderSummaryViewModel>;

                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetOrderAsync()
        {
            using (var repository = RepositoryMocker.GetSalesRepository())
            {
                // Arrange
                var controller = new SalesController(repository);
                var id = 75123;

                // Act
                var response = await controller.GetOrder(id) as ObjectResult;

                // Assert
                var value = response.Value as ISingleModelResponse<OrderHeaderViewModel>;

                Assert.False(value.DidError);
            }
        }

        [Fact]
        public async Task TestGetOrderNotFoundAsync()
        {
            using (var repository = RepositoryMocker.GetSalesRepository())
            {
                // Arrange
                var controller = new SalesController(repository);
                var id = 0;

                // Act
                var response = await controller.GetOrder(id) as ObjectResult;

                // Assert
                var value = response.Value as ISingleModelResponse<OrderHeaderViewModel>;

                Assert.False(value.DidError);
            }
        }
    }
}
