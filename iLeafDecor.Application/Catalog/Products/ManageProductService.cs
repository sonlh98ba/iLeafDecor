using iLeafDecor.Application.Catalog.Products.DTOs;
using iLeafDecor.Application.Catalog.Products.DTOs.Manage;
using iLeafDecor.Application.DTOs;
using iLeafDecor.Data.EF;
using iLeafDecor.Data.Entities;
using iLeafDecor.Ultilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ILeafDBContext _context;
        public ManageProductService(ILeafDBContext context)
        {
            _context = context;
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
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
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

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productID)
        {
            var product = await _context.Products.FindAsync();
            if (product == null) throw new ILeafException($"Cannot find product with id: {productID}");
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

        public async Task AddViewCount(int productID)
        {
            var product = await _context.Products.FindAsync();
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            // Select all table
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductID
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductID
                        join c in _context.Categories on pic.CategoryID equals c.ID
                        select new { p, pt, pic};

            // Filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x=>x.pt.Name.Contains(request.Keyword));

            if(request.CategoryIDs.Count > 0)
            {
                query = query.Where(p=>request.CategoryIDs.Contains(p.pic.CategoryID));
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
    }
}
