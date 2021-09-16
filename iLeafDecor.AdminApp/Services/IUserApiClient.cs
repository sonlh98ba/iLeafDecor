using iLeafDecor.ViewModels.Common;
using iLeafDecor.ViewModels.System.Users;
using System.Threading.Tasks;

namespace iLeafDecor.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);

        Task<PagedResult<UserVM>> GetUsersPagings(GetUserPagingRequest request);

        Task<bool> RegisterUser(RegisterRequest registerRequest);
    }
}
