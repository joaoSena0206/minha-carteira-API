using System.ComponentModel.DataAnnotations;

namespace back_end.Models;

public class Category
{
    public int Id { get; set; }

    [MaxLength(100)] public string Name { get; set; } = "";
    
    public User User { get; set; } = new User();
    public ICollection<FinancialGoal> FinancialGoals { get; set; } = new List<FinancialGoal>();
}