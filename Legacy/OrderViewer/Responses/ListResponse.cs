﻿using System;
using System.Collections.Generic;

namespace OrderViewer.Responses
{
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public IEnumerable<TModel> Model { get; set; }

        public Int32 PageSize { get; set; }

        public Int32 PageNumber { get; set; }

        public Int32 ItemsCount { get; set; }

        public Int32 PageCount =>
            PageSize == 0 ? 0 : ItemsCount / PageSize;
    }
}
