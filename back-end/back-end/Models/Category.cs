using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_end.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)] 
    public string Name { get; set; } = "";
    
    [JsonIgnore]
    public User? User { get; set; }
    
    [JsonIgnore]
    public ICollection<FinancialGoal> FinancialGoals { get; set; } = new List<FinancialGoal>();
    
    [JsonIgnore]
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}