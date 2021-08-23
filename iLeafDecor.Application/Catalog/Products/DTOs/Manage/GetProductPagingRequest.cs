using iLeafDecor.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Application.Catalog.Products.DTOs.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIDs { get; set; }
    }
}
