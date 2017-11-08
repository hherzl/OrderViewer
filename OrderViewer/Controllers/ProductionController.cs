using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.Repositories;
using OrderViewer.Responses;
using OrderViewer.ViewModels;

namespace OrderViewer.Controllers
{
    [Route("api/[controller]")]
    public class ProductionController : Controller
    {
        private IProductionRepository ProductionRepository;

        public ProductionController(IProductionRepository repository)
        {
            ProductionRepository = repository;
        }

        protected override void Dispose(Boolean disposing)
        {
            ProductionRepository?.Dispose();

            base.Dispose(disposing);
        }

        /// <summary>
        /// Retrieve the product subcategories
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Page number</param>
        /// <returns>A ListModelResponse of ProductSubcategoryViewModel</returns>
        [HttpGet("ProductSubcategory")]
        public async Task<IActionResult> GetProductSubcategoriesAsync(Int32? pageSize = 10, Int32? pageNumber = 1)
        {
            var response = new ListResponse<ProductSubcategoryViewModel>();

            try
            {
                // Get query
                var query = ProductionRepository.GetProductSubcategories();

                // Set information for paging
                response.PageSize = (Int32)pageSize;
                response.PageNumber = (Int32)pageNumber;
                response.ItemsCount = await query.CountAsync();

                // Retrieve items
                var list = await query
                    .Paging((Int32)pageSize, (Int32)pageNumber)
                    .ToListAsync();

                // Set model for response
                response.Model = list.Select(item => item.ToViewModel());

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response.ToHttpResponse();
        }
    }
}
