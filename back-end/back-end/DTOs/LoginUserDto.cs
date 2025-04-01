using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs;

public class LoginUserDto
{
    [Required(ErrorMessage = "Nome de usuário obrigatório!")]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "Senha obrigatória!")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
}