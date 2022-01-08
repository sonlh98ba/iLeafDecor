using iLeafDecor.Data.EF;
using iLeafDecor.ViewModels.Common;
using iLeafDecor.ViewModels.System.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLeafDecor.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _config;
        private readonly ILeafDBContext _context;

        public LanguageService(ILeafDBContext context,
            IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageVM>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVM()
            {
                Id = x.ID,
                Name = x.Name
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVM>>(languages);
        }
    }
}
