using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.Controllers;
using OrderViewer.Responses;
using OrderViewer.ViewModels;
using Xunit;

namespace OrderViewer.Tests
{
    public class ProductionControllerTests
    {
        [Fact]
        public async Task TestGetProductSubcategoriesAsync()
        {
            // Arrange
            var repository = RepositoryMocker.GetProductionRepository();
            var controller = new ProductionController(repository);

            // Act
            var response = await controller.GetProductSubcategoriesAsync() as ObjectResult;
            var value = response.Value as IListResponse<ProductSubcategoryViewModel>;

            repository.Dispose();

            // Assert
            Assert.False(value.DidError);
        }
    }
}
