using iLeafDecor.ViewModels.Common;
using iLeafDecor.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iLeafDecor.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);

        Task<PagedResult<UserVM>> GetUsersPaging(GetUserPagingRequest request);
    }
}
