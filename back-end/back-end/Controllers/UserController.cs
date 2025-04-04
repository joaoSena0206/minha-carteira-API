using System.Security.Claims;
using back_end.Models;
using back_end.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteUser()
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        await _userService.DeleteUser(username);

        return NoContent();
    }
}