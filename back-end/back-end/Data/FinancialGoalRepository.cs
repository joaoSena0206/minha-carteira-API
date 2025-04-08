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

    public async Task<List<FinancialGoal>> GetAll(int? month, int? year, string username)
    {
        var query = _context.FinancialGoals
            .Where(f => f.User.Username == username)
            .Include(f => f.Category)
            .AsQueryable();

        if (month != null)
        {
            query = query.Where(f => f.Month == month);
        }

        if (year != null)
        {
            query = query.Where(f => f.Year == year);
        }

        return await query.ToListAsync();
    }

    public async Task<FinancialGoal> GetById(int id, string username)
    {
        return await _context.FinancialGoals.FirstOrDefaultAsync(f => f.Id == id && f.User.Username == username);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}