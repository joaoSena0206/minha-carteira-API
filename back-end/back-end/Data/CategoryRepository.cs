using back_end.DTOs;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public class CategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        
        return category.Id;
    }

    public async Task<Category> GetCategory(int id, string username)
    {
        return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id && c.User.Username == username);
    }

    public async Task<List<Category>> GetCategories(string username)
    {
        List<Category> categories = await _context.Categories
            .Where(c => c.User.Username == username)
            .ToListAsync();

        return categories;
    }

    public async Task DeleteCategory(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}