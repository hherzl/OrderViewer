using System;
using OrderViewer.Responses;

namespace OrderViewer.Helpers
{
    public static class Error
    {
        public static void Publish<TModel>(this Exception ex, IListModelResponse<TModel> response)
        {
            response.DidError = true;
            response.ErrorMessage = ex.Message;

            // todo: Add code to save exception in log file

            // todo: Add code to save exception in database

            // todo: Add code to send an email if exception is critical
        }

        public static void Publish<TModel>(this Exception ex, ISingleModelResponse<TModel> response)
        {
            response.DidError = true;
            response.ErrorMessage = ex.Message;

            // todo: Add code to save exception in log file

            // todo: Add code to save exception in database

            // todo: Add code to send an email if exception is critical
        }
    }
}
