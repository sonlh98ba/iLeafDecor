using iLeafDecor.ViewModels.Common;
using iLeafDecor.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVM>>> GetAll();
    }
}
