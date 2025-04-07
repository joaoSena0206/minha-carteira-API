using System.ComponentModel.DataAnnotations;
using back_end.Models;

namespace back_end.DTOs;

public class AddCategoryDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [MaxLength(100,  ErrorMessage = "Máximo de 100 caracteres para o nome")] 
    public string Name { get; set; } = "";
}