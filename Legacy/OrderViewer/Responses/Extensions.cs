using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace OrderViewer.Responses
{
    public static class Extensions
    {
        public static void SetError(this IResponse response, Exception ex)
        {
            // todo: Add code to save exception in log file
            // todo: Add code to save exception in database
            // todo: Add code to send an email if exception is critical

            response.DidError = true;
            response.ErrorMessage = ex.Message;
        }

        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response)
            {
                StatusCode = (Int32)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NotFound;
            }

            return new ObjectResult(response)
            {
                StatusCode = (Int32)status
            };
        }
    }
}
