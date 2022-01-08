using iLeafDecor.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVM>> GetAll();
    }
}
