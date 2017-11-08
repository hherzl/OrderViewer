using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.Controllers;
using OrderViewer.Responses;
using OrderViewer.ViewModels;
using Xunit;

namespace OrderViewer.Tests
{
    public class SalesControllerTests
    {
        [Fact]
        public async Task TestGetOrdersAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetSalesRepository();
            var controller = new SalesController(repository);

            // Act
            var response = await controller.GetOrdersAsync() as ObjectResult;
            var value = response.Value as IListResponse<OrderSummaryViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.DidError);
            Assert.True(value.Model.Count() > 0);
        }

        [Fact]
        public async Task TestGetOrdersSearchingBySalesOrderNumberAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetSalesRepository();
            var controller = new SalesController(repository);
            var salesOrderNumber = "so72";

            // Act
            var response = await controller.GetOrdersAsync(salesOrderNumber: salesOrderNumber) as ObjectResult;
            var value = response.Value as IListResponse<OrderSummaryViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestGetOrdersSearchingByCustomerNameAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetSalesRepository();
            var controller = new SalesController(repository);
            var customerName = "her";

            // Act
            var response = await controller.GetOrdersAsync(customerName: customerName) as ObjectResult;
            var value = response.Value as IListResponse<OrderSummaryViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestGetOrdersSearchingBySalesOrderNumberAndCustomerNameAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetSalesRepository();
            var controller = new SalesController(repository);
            var salesOrderNumber = "so72";
            var customerName = "her";

            // Act
            var response = await controller.GetOrdersAsync(salesOrderNumber: salesOrderNumber, customerName: customerName) as ObjectResult;
            var value = response.Value as IListResponse<OrderSummaryViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestGetOrderAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetSalesRepository();
            var controller = new SalesController(repository);
            var id = 75123;

            // Act
            var response = await controller.GetOrderAsync(id) as ObjectResult;
            var value = response.Value as ISingleResponse<OrderHeaderViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestGetOrderNotFoundAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetSalesRepository();
            var controller = new SalesController(repository);
            var id = 0;

            // Act
            var response = await controller.GetOrderAsync(id) as ObjectResult;
            var value = response.Value as ISingleResponse<OrderHeaderViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.DidError);
        }
    }
}
