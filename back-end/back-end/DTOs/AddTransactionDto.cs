using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back_end.Models;

namespace back_end.DTOs;

public class AddTransactionDto
{
    [Required(ErrorMessage = "Valor é obrigatório!")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0!")]
    public decimal Value { get; set; }
    
    [MaxLength(500, ErrorMessage = "Descrição de no máximo 500 caracteres!")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Obrigatório o tipo de transação!")]
    public bool IsCredit { get; set; }
    
    [Required(ErrorMessage = "Data da transação obrigatória!")]
    public DateTime Date { get; set; }
    
    public int CategoryId { get; set; }
}