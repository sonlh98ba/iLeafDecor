using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Catalog.Products.Public;
using iLeafDecor.ViewModels.Common;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request);
    }
}
