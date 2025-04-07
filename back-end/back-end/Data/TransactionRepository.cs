using back_end.DTOs;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public class TransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<Transaction>> GetTransactions(
        string username,
        DateTime? startDate,
        DateTime? endDate,
        bool? isCredit,
        int? categoryId)
    {
        var query = _context.Transactions
            .Where(t => t.User.Username == username)
            .Include(t => t.Category)
            .AsQueryable();

        if (startDate != null)
        {
            query = query.Where(t => t.Date >= startDate);
        }

        if (endDate != null)
        {
            query = query.Where(t => t.Date <= endDate);
        }

        if (isCredit != null)
        {
            query = query.Where(t => t.IsCredit == isCredit);
        }

        if (categoryId != null)
        {
            query = query.Where(t => t.Category.Id == categoryId);
        }

        return await query.ToListAsync();
    }

    public async Task<int> AddTransaction(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
        
        return transaction.Id;
    }

    public async Task<decimal> GetBalance(string username)
    {
        List<Transaction> transactions = await _context.Transactions
            .Where(t => t.User.Username == username)
            .ToListAsync();
        
        decimal balance = transactions.Sum(t => t.IsCredit ? t.Value : -t.Value);

        return balance;
    }

    public async Task<Transaction> GetTransaction(int transactionId, string username)
    {
        return await _context.Transactions
            .FirstOrDefaultAsync(t => t.Id == transactionId && t.User.Username == username);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransaction(Transaction transaction)
    {
        _context.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}