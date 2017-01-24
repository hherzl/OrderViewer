using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.DataContracts;
using OrderViewer.Extensions;
using OrderViewer.Responses;

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
            var response = new ListModelResponse<OrderSummaryViewModel>() as IListModelResponse<OrderSummaryViewModel>;

            try
            {
                response.PageSize = (Int32)pageSize;
                response.PageNumber = (Int32)pageNumber;

                response.Model = await Task.Run(() =>
                {
                    return SalesRepository
                        .GetOrders((Int32)pageSize, (Int32)pageNumber, salesOrderNumber, customerName);
                });

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
            var response = new SingleModelResponse<OrderHeaderViewModel>() as ISingleModelResponse<OrderHeaderViewModel>;

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return SalesRepository.GetOrder(id);
                });
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
