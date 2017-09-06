using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.Repositories;
using OrderViewer.Extensions;
using OrderViewer.Responses;
using OrderViewer.ViewModels;

namespace OrderViewer.Controllers
{
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
        private ISalesRepository SalesRepository;

        public SalesController(ISalesRepository repository)
        {
            SalesRepository = repository;
        }

        protected override void Dispose(Boolean disposing)
        {
            SalesRepository?.Dispose();

            base.Dispose(disposing);
        }

        /// <summary>
        /// Retrieves a list of orders that match with criteria
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="salesOrderNumber">Sales order number</param>
        /// <param name="customerName">Customer name</param>
        /// <returns>A ListModelResponse of OrderSummaryViewModel</returns>
        [HttpGet("Order")]
        public async Task<IActionResult> GetOrders(Int32? pageSize = 10, Int32? pageNumber = 1, String salesOrderNumber = "", String customerName = "")
        {
            var response = new ListResponse<OrderSummaryViewModel>();

            try
            {
                // Get query
                var query = SalesRepository.GetOrders(salesOrderNumber, customerName);

                // Set information for paging
                response.PageSize = (int)pageSize;
                response.PageNumber = (int)pageNumber;
                response.ItemsCount = await query.CountAsync();

                // Retrieve items
                var list = await query.Paging((int)pageSize, (int)pageNumber).ToListAsync();

                // Set model for response
                response.Model = list.Select(item => item.ToViewModel());

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Retrieves an existing order by id
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns>A SingleModelResponse of OrderHeaderViewModel</returns>
        [HttpGet("Order/{id}")]
        public async Task<IActionResult> GetOrder(Int32 id)
        {
            var response = new SingleResponse<OrderHeaderViewModel>();

            try
            {
                var entity = await SalesRepository.GetOrderAsync(id);

                response.Model = entity.ToViewModel();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
