using ExpiryLogger.Api.Helpers;
using ExpiryLogger.Api.Models;
using ExpiryLogger.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpiryLogger.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        if (response is null)
            return BadRequest(new { message = "Username or password is incorrect" });
        else
            return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
