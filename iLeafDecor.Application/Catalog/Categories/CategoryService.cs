using iLeafDecor.Data.EF;
using iLeafDecor.ViewModels.Catalog.Categories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ILeafDBContext _context;

        public CategoryService(ILeafDBContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoriesTranslations on c.ID equals ct.CategoryID
                        where ct.LanguageID == languageId
                        select new { c, ct };

            return await query.Select(x => new CategoryVM()
            {
                Id = x.c.ID,
                Name = x.ct.Name
            }).ToListAsync();
        }
    }
}
