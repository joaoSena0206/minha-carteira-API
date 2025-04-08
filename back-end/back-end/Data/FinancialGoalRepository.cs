using back_end.DTOs;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public class FinancialGoalRepository
{
    private readonly ApplicationDbContext _context;

    public FinancialGoalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(FinancialGoal financialGoal)
    {
        await _context.FinancialGoals.AddAsync(financialGoal);
        await _context.SaveChangesAsync();
        
        return financialGoal.Id;
    }

    public async Task<List<FinancialGoalWithTransactionsDto>> GetAll(int? month, int? year, string username)
    {
        List<FinancialGoalWithTransactionsDto> financialGoals = await _context.FinancialGoals
            .Where(f => f.User.Username == username &&
                        (month == null || f.Month == month) &&
                        (year == null || f.Year == year))
            .Select(f => new FinancialGoalWithTransactionsDto
            {
                Id = f.Id,
                Month = f.Month,
                Year = f.Year,
                ValueLimit = f.ValueLimit,
                Category = f.Category,
                Transactions = f.Category.Transactions
                    .Where(t =>
                        t.Date.Month == f.Month &&
                        t.Date.Year == f.Year &&
                        t.IsCredit == false)
                    .ToList()
            })
            .ToListAsync();
        
        return financialGoals;
    }

    public async Task<FinancialGoal> GetById(int id, string username)
    {
        return await _context.FinancialGoals.FirstOrDefaultAsync(f => f.Id == id && f.User.Username == username);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Delete(FinancialGoal financialGoal)
    {
        _context.FinancialGoals.Remove(financialGoal);
        await _context.SaveChangesAsync();
    }
}