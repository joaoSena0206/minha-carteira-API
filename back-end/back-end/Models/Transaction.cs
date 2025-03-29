namespace back_end.Models;

public class Transaction
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public bool IsCredit { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    
    public required Category Category { get; set; }
    public required User User { get; set; }
}