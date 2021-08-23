using iLeafDecor.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Application.Catalog.Products.DTOs.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryID { get; set; }
    }
}
