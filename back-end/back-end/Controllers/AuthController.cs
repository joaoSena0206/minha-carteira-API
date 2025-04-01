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
        try
        {
            await _authService.RegisterUser(userDto);

            return StatusCode(201, new
            {
                message = "Usuário registrado com sucesso!",
                username = userDto.Username
            });
        }
        catch (UserAlreadyExistsException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao registrar o usuário" });
        }
    }

    [HttpPost("login")]
    public IActionResult LoginUser(LoginUserDto userDto)
    {
        try
        {
            string token = _authService.LoginUser(userDto);

            return Ok("Usuário logado com sucesso");
        }
        catch
        {
            return BadRequest("Erro ao logar o usuário!");
        }
    }
}