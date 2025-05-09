using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<User?> GetUser(string username)
    {
        return await _context.Users.FindAsync(username);
    }

    public async Task DeleteUser(string username)
    {
        _context.Remove(await _context.Users.SingleAsync(u => u.Username == username));
        await _context.SaveChangesAsync();
    }
}