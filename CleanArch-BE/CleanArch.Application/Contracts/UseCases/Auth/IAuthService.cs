using CleanArch.Application.DTOs.Auth;
using CleanArch.Application.DTOs.Users;

namespace CleanArch.Application.Contracts.UseCases.Auth;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    Task<UserResponse> RegisterAsync(CreateUserRequest request, CancellationToken cancellationToken);
}

