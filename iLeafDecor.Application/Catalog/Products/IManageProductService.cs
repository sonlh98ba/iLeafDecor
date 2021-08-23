using iLeafDecor.Application.Catalog.Products.DTOs;
using iLeafDecor.Application.Catalog.Products.DTOs.Manage;
using iLeafDecor.Application.DTOs;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productID);

        Task<bool> UpdatePrice(int productID, decimal newPrice);

        Task<bool> UpdateStock(int productID, int addedQuantity);

        Task AddViewCount(int productID);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
