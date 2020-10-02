using WebApi.Models;

namespace WebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;

        public AuthenticationService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            // TODO: implement real authentication
            var user = new UserInfo()
            {
                UserId = "User12345",
            };

            var token = _tokenService.GetToken(user);

            return new AuthenticationResponse()
            {
                UserName = request.Username,
                Token = token
            };
        }
    }
}