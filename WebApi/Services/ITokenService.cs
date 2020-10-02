using WebApi.Models;

namespace WebApi.Services
{
    public interface ITokenService
    {
        string GetToken(UserInfo user);
    }
}