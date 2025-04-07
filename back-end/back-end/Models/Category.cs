using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)] 
    public string Name { get; set; } = "";
    
    public string Username { get; set; } = "";
    
    [ForeignKey("Username")]
    public User? User { get; set; }
    public ICollection<FinancialGoal> FinancialGoals { get; set; } = new List<FinancialGoal>();
}