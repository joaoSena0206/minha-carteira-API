using back_end.DTOs;
using back_end.Models;

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
}