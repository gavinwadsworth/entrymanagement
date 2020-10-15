using EMSAdminSPA.Models;
using System.Threading.Tasks;

namespace EMSAdminSPA.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
