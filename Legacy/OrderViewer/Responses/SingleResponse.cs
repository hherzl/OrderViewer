using System;

namespace OrderViewer.Responses
{
    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
