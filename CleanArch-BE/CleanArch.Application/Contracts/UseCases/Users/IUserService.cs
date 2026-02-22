using CleanArch.Application.DTOs.Users;

namespace CleanArch.Application.Contracts.UseCases.Users;

public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<UserResponse> UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    Task<UserResponse?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<UserResponse?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}