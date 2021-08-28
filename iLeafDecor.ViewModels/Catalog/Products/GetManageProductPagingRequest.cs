using iLeafDecor.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIDs { get; set; }
    }
}
