using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs;

public class RegisterUserDto
{
    [Required(ErrorMessage = "Nome de usuário obrigatório!")]
    [MaxLength(100, ErrorMessage = "Nome de usuário deve ter no máximo 100 caracteres!")]
    public required string Username { get; set; }
    
    [Required(ErrorMessage = "Senha obrigatória!")]
    [MinLength(8, ErrorMessage = "Senha deve ter pelo menos 8 caracteres!")]
    [MaxLength(16, ErrorMessage = "Senha deve ter no máximo 16 caracteres!")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}