using iLeafDecor.ViewModels.Common;

namespace iLeafDecor.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryID { get; set; }
    }
}
