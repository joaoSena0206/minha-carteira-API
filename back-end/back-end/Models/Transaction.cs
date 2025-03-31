using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

public class Transaction
{
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Value { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    public bool IsCredit { get; set; }
    public DateTime Date { get; set; }
    
    public Category? Category { get; set; }
    public User User { get; set; } = new User();
}