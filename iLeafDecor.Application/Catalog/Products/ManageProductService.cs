using iLeafDecor.Application.Catalog.ProductImages;
using iLeafDecor.Application.Common;
using iLeafDecor.Data.EF;
using iLeafDecor.Data.Entities;
using iLeafDecor.Ultilities.Exceptions;
using iLeafDecor.ViewModels.Catalog.ProductImages;
using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ILeafDBContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(ILeafDBContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                Stock = request.Stock,
                ViewCount = 0,
                CreatedDate = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name =  request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTittle = request.SeoTittle,
                        LanguageID = request.LanguageID
                    }
                }
            };

            // Save image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        CreatedDate = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.ID;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.ID);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductID == request.ID && x.LanguageID == request.LanguageID);
            if (product == null || productTranslation == null) throw new ILeafException($"Cannot find product with id: {request.ID}");

            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTittle = request.SeoTittle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductID == request.ID);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productID)
        {
            var product = await _context.Products.FindAsync();
            if (product == null) throw new ILeafException($"Cannot find product with id: {productID}");

            var images = _context.ProductImages.Where(i => i.ProductID == productID);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productID, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null) throw new ILeafException($"Cannot find product with id: {productID}");

            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productID, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null) throw new ILeafException($"Cannot find product with id: {productID}");

            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> AddImage(int productID, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                ProductID = productID,
                Caption = request.Caption,
                CreatedDate = DateTime.Now,
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder
            };

            // Save image
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }

            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.ID;
        }

        public async Task<int> RemoveImage(int imageID)
        {
            var productImage = await _context.ProductImages.FindAsync(imageID);
            if (productImage == null)
                throw new ILeafException($"Can not find an image with id {imageID}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> UpdateImage(int imageID, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageID);
            if (productImage == null)
                throw new ILeafException($"Can not find an image with id {imageID}");

            // Save image
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }

            _context.ProductImages.Update(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productID)
        {
            return await _context.ProductImages.Where(x => x.ProductID == productID)
                .Select(i => new ProductImageViewModel()
                {
                    ID = i.ID,
                    Caption = i.Caption,
                    CreatedDate = i.CreatedDate,
                    FileSize = i.FileSize,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductID = i.ProductID,
                    SortOrder = i.SortOrder
                }).ToListAsync();
        }

        public async Task AddViewCount(int productID)
        {
            var product = await _context.Products.FindAsync();
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            // Select all table
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductID
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductID
                        join c in _context.Categories on pic.CategoryID equals c.ID
                        select new { p, pt, pic };

            // Filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            if (request.CategoryIDs.Count > 0)
            {
                query = query.Where(p => request.CategoryIDs.Contains(p.pic.CategoryID));
            }

            // Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(x => new ProductViewModel()
                            {
                                ID = x.p.ID,
                                Name = x.pt.Name,
                                Price = x.p.Price,
                                CreatedDate = x.p.CreatedDate,
                                Description = x.pt.Description,
                                Details = x.pt.Details,
                                LanguageID = x.pt.LanguageID,
                                SeoAlias = x.pt.SeoAlias,
                                SeoDescription = x.pt.SeoDescription,
                                SeoTittle = x.pt.SeoTittle,
                                Stock = x.p.Stock,
                                ViewCount = x.p.ViewCount
                            }).ToListAsync();

            // Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<ProductViewModel> GetByID(int productID, string languageID)
        {
            var product = await _context.Products.FindAsync(productID);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductID == productID && x.LanguageID == languageID);

            var productViewModel = new ProductViewModel()
            {
                ID = product.ID,
                CreatedDate = product.CreatedDate,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageID = productTranslation.LanguageID,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTittle = productTranslation != null ? productTranslation.SeoTittle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount
            };
            return productViewModel;
        }

        public async Task<ProductImageViewModel> GetImageByID(int imageID)
        {
            var image = await _context.ProductImages.FindAsync(imageID);
            if (image == null)
                throw new ILeafException($"Can not find an image with id {imageID}");

            var viewModel = new ProductImageViewModel()
            {
                ID = image.ID,
                Caption = image.Caption,
                CreatedDate = image.CreatedDate,
                FileSize = image.FileSize,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductID = image.ProductID,
                SortOrder = image.SortOrder
            };

            return viewModel;
        }
    }
}
