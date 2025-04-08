using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
using back_end.Models;

namespace back_end.DTOs;

public class UpdateFinancialGoalDto
{
    [Column(TypeName = "decimal(18,2)")]
    public decimal? ValueLimit { get; set; } = null;

    [Range(1, 12, ErrorMessage = "O mês deve estar entre 1 e 12")]
    public int? Month { get; set; } = null;
    
    public int? Year { get; set; } = null;

    public int? CategoryId { get; set; } = null;
}