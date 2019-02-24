using System;
using System.Collections.Generic;

namespace OrderViewer.Responses
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }

        Int32 PageSize { get; set; }

        Int32 PageNumber { get; set; }

        Int32 ItemsCount { get; set; }

        Int32 PageCount { get; }
    }
}
