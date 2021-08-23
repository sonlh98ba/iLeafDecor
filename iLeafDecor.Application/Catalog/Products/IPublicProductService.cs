using iLeafDecor.Application.Catalog.Products.DTOs;
using iLeafDecor.Application.Catalog.Products.DTOs.Public;
using iLeafDecor.Application.DTOs;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request);
    }
}
