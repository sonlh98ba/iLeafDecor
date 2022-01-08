using iLeafDecor.ViewModels.Common;
using iLeafDecor.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.ApiIntegration
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVM>>> GetAll();
    }
}
