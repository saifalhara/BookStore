using BookStore.Controllers.Base;
using Domain.Dtos.UserDtos.Requests;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Authentications;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationsController(
        IAuthenticatioService _authenticationService
        ) : BaseController
{
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody]LoginDto Login)
    {
        try
        {
            var result = await _authenticationService.Login(Login);
            return result.IsSuccess ? Ok(result.Response) : BadRequest(result.Error);
        }
        catch
        {
            throw;
        }
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody]UserDto registerDto)
    {
        try
        {
            var result = await _authenticationService.Register(registerDto);
            return result.IsSuccess ? Created() : BadRequest(result.Error);
        }
        catch
        {
            throw;
        }
    }
}
