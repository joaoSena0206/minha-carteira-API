using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

public class FinancialGoal
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal ValueLimit { get; set; }
    
    [Required]
    public int Month { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    public User User { get; set; } = new User();
    public Category Category { get; set; } = new Category();
}