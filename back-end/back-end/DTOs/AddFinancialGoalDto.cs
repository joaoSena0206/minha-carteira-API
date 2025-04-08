using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back_end.Models;

namespace back_end.DTOs;

public class AddFinancialGoalDto
{
    [Required(ErrorMessage = "Valor limite é obrigatório")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal ValueLimit { get; set; }
    
    [Required(ErrorMessage = "Mês é obrigatório")]
    public int Month { get; set; }
    
    [Required(ErrorMessage = "Ano é obrigatório")]
    public int Year { get; set; }
    
    [Required(ErrorMessage = "Id da categoria é obrigatório")]
    public int CategoryId { get; set; }
}