namespace back_end.Models;

public class FinancialGoal
{
    public int Id { get; set; }
    public decimal ValueLimit { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    
    public required User User { get; set; }
    public required Category Category { get; set; }
}