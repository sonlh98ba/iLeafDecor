using iLeafDecor.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVM>> GetAll(string languageId);
    }
}
