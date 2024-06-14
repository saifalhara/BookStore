using Domain.Dtos.Sheard;
using Domain.Dtos.UserDtos.Requests;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Users;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class UsersController(
        IUserServices _userServices
    ) : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromForm] UserDto userDto)
    {
        var result = await _userServices.Create(userDto);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        var result = await _userServices.Get();
        return result.IsSuccess ? Ok(result.Response) : BadRequest(result.Error);
    }

    [HttpGet]
    [Route("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _userServices.GetById(id);
        return result.IsSuccess ? Ok(result.Response) : BadRequest(result.Error);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(Delete deleteUser)
    {
        var result = await _userServices.Delete(deleteUser);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpPut]
    [Route("Update/{id:int}")]
    public async Task<IActionResult> Update(int id, UserDto userDto)
    {
        var result = await _userServices.Update(id, userDto);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpPut]
    [Route("Join")]
    public async Task<IActionResult> Join()
    {
        var result = await _userServices.Join();
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpPut]
    [Route("Leave")]
    public async Task<IActionResult> Leave()
    {
        var result = await _userServices.Leave();
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

}
