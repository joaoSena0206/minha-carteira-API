using back_end.DTOs;
using back_end.Exceptions;
using back_end.Services;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserDto userDto)
    {
        await _authService.RegisterUser(userDto);

        return StatusCode(201, new
        {
            message = "Usuário registrado com sucesso!",
            username = userDto.Username
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(LoginUserDto userDto)
    {
        string tokenJwt = await _authService.LoginUser(userDto);

        return Ok(new { token = tokenJwt , username = userDto.Username });
    }
}