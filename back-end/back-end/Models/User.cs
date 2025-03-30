using System.ComponentModel.DataAnnotations;

namespace back_end.Models;

public class User
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public required string Username { get; set; }
    
    [MaxLength(16)]
    public required string Password { get; set; }
    
    public ICollection<Transaction> Transactions { get; } = new List<Transaction>();
    public ICollection<Category> Categories { get; } = new List<Category>();
    public ICollection<FinancialGoal> FinancialGoals { get; } = new List<FinancialGoal>();
}