using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs;

public class UpdateCategoryDto
{
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres para o nome")]
    public string? Name { get; set; } = null;
}