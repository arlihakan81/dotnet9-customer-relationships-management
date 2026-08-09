using CRM.Application.Interfaces;
using CRM.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            if(ModelState.IsValid)
            {
                return Ok(await authService.LoginAsync(request));
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            if(ModelState.IsValid)
            {
                await authService.RegisterAsync(request);
                return Created();
            }
            return BadRequest("An error occured");
        }



    }
}
