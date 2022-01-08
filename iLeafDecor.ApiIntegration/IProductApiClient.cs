using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVM>> GetPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<ProductVM> GetById(int id, string languageId);

        Task<List<ProductVM>> GetFeaturedProducts(string languageId, int take);
    }
}
