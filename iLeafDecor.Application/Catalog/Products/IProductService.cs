using iLeafDecor.Application.Catalog.ProductImages;
using iLeafDecor.ViewModels.Catalog.ProductImages;
using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productID);

        Task<ProductViewModel> GetByID(int productID, string languageID);

        Task<bool> UpdatePrice(int productID, decimal newPrice);

        Task<bool> UpdateStock(int productID, int addedQuantity);

        Task AddViewCount(int productID);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImage(int productID, ProductImageCreateRequest request);
        Task<int> RemoveImage(int imageID);
        Task<int> UpdateImage(int imageID, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageByID(int imageID);
        Task<List<ProductImageViewModel>> GetListImages(int productID);

        public Task<PagedResult<ProductViewModel>> GetAllByCategoryID(string languageID, GetPublicProductPagingRequest request);
    }
}
