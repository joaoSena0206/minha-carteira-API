using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace back_end.Models;

[PrimaryKey("Username")]
public class User
{
    [Required]
    [MaxLength(100)] public string Username { get; set; } = "";

    [Required] 
    public string Password { get; set; } = "";
    
    public ICollection<Transaction> Transactions { get; } = new List<Transaction>();
    public ICollection<Category> Categories { get; } = new List<Category>();
    public ICollection<FinancialGoal> FinancialGoals { get; } = new List<FinancialGoal>();
}