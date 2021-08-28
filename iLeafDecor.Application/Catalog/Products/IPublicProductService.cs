using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetPublicProductPagingRequest request);
        public Task<List<ProductViewModel>> GetAll();
    }
}
