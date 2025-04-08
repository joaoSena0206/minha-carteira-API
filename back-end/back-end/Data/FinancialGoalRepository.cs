using back_end.DTOs;
using back_end.Models;

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
}