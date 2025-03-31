using back_end.DTOs;
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

    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterUserDto userDto)
    {
        try
        {
            await _authService.RegisterUser(userDto);

            return Ok("Usuário registrado com sucesso!");
        }
        catch
        {
            return BadRequest("Erro ao registrar o usuário!");
        }
    }
}