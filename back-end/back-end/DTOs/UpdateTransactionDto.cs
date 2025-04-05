using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs;

public class UpdateTransactionDto
{
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0!")]
    public decimal? Value { get; set; } = null;

    [MaxLength(500, ErrorMessage = "Descrição de no máximo 500 caracteres!")]
    public string? Description { get; set; } = null;
    
    public bool? IsCredit { get; set; } = null;
    
    public DateTime? Date { get; set; } = null;
    
    public int? CategoryId { get; set; } = null;
}