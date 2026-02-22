using CleanArch.Domain.Models;

namespace CleanArch.Application.Contracts.Persistence;

public interface IUserRepository
{
    
    public Task<User> CreateAsync(User user, CancellationToken cancellationToken);
    public Task<User> Update(User user, CancellationToken cancellationToken);
    public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    
    // public int Id { get; set; }
    // public string Username { get; set; }
    // public string PasswordHashed { get; set; }
    // public string Email { get; set; }
}