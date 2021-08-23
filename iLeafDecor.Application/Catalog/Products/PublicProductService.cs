using iLeafDecor.Data.EF;
using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Catalog.Products.Public;
using iLeafDecor.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly ILeafDBContext _context;
        public PublicProductService(ILeafDBContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request)
        {
            // Select all table
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductID
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductID
                        join c in _context.Categories on pic.CategoryID equals c.ID
                        select new { p, pt, pic };

            // Filter
            if (request.CategoryID.HasValue && request.CategoryID.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryID == request.CategoryID);
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
