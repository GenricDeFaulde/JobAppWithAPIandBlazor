using JobAppPortal.Models;
using System.Threading.Tasks;

namespace JobAppPortal.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthentication);
        Task Logout();
    }
}