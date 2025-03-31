using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

public class Transaction
{
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    [Required]
    public decimal Value { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    [Required]
    public bool IsCredit { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    public Category? Category { get; set; }
    public User User { get; set; } = new User();
}