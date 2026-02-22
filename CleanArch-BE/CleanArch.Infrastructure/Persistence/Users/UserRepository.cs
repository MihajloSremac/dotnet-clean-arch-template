using Microsoft.EntityFrameworkCore;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain.Models;

namespace CleanArch.Infrastructure.Persistence.Users;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    
    public UserRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }
    
    public async Task<User> Update(User user, CancellationToken cancellationToken)
    {
        _context.Users.Update(user); 
        await _context.SaveChangesAsync(cancellationToken); 
        return user; 
    }
    
    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}