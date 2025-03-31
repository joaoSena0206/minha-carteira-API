using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

public class FinancialGoal
{
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal ValueLimit { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    
    public User User { get; set; } = new User();
    public Category Category { get; set; } = new Category();
}