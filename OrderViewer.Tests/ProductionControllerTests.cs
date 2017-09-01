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
            using (var repository = RepositoryMocker.GetProductionRepository())
            {
                // Arrange
                var controller = new ProductionController(repository);

                // Act
                var response = await controller.GetProductSubcategories() as ObjectResult;

                // Assert
                var value = response.Value as IListResponse<ProductSubcategoryViewModel>;

                Assert.False(value.DidError);
            }
        }
    }
}
