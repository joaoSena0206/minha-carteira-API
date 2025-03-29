namespace back_end.Data;

using Microsoft.EntityFrameworkCore;
using back_end.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FinancialGoal> FinancialGoals { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}