using iLeafDecor.ViewModels.System.Users;
using System.Threading.Tasks;

namespace iLeafDecor.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
