using System.ComponentModel.DataAnnotations;

namespace back_end.Models;

public class Category
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public required string Name { get; set; }
    
    public required User User { get; set; }
    public ICollection<FinancialGoal> FinancialGoals { get; set; } = new List<FinancialGoal>();
}