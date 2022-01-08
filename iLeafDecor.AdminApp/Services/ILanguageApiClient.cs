using iLeafDecor.ViewModels.Common;
using iLeafDecor.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.AdminApp.Services
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageVM>>> GetAll();
    }
}
