using CRM.API.DTOs;
using CRM.API.Interfaces;
using CRM.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public IActionResult Signup(RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _authService.Register(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _authService.Login(dto);

            if (!result.Success)
                return BadRequest(result.Message);


            return Ok(result);
         
        }

    }
}
