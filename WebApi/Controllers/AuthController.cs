using Authentication;
using Infrastructure.Business.Domains.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var token = await _authService.LoginAsync(request);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
