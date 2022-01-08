using iLeafDecor.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAll(string languageId);
    }
}
