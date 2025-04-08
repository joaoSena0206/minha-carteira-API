using System.ComponentModel.DataAnnotations.Schema;
using back_end.Models;

namespace back_end.DTOs;

public class FinancialGoalWithTransactionsDto
{
    public int Id { get; set; }
    
    public Category Category { get; set; } = new Category();
    
    public int Month { get; set; }
    
    public int Year { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal ValueLimit { get; set; }
    
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}