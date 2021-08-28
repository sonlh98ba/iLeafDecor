using iLeafDecor.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryID { get; set; }
    }
}
