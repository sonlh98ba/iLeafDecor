using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Catalog.Products.Manage;
using iLeafDecor.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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
        Task<int> AddImages(int productID, List<IFormFile> files);
        Task<int> RemoveImages(int imageID);
        Task<int> UpdateImages(int imageID, string caption, bool isDefault);
        Task<List<ProductImageViewModel>> GetListImage(int productID);
    }
}
