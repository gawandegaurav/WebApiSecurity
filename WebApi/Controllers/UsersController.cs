using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public UsersController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate(AuthenticationRequest request)
        {
            var response = _authenticationService.Authenticate(request);
            if (response == null)
            {
                return new BadRequestResult();
            }

            return Ok(response);
        }

        [HttpPost("updateprofile")]
        [RequiredAuthenticated]
        public IActionResult UpdateProfile(UpdateProfileRequest request)
        {
            return Ok("Profile updated");
        }
    }
}
