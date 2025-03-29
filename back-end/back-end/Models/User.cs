namespace back_end.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string PreferredCurrency { get; set; }
    
    public required ICollection<Transaction> Transactions { get; set; }
    public required ICollection<Category> Categories { get; set; }
}