using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Application.Contracts.UseCases.Auth;
using CleanArch.Application.DTOs.Auth;
using CleanArch.Application.DTOs.Users;
using CleanArch.Domain.Models;

namespace CleanArch.Application.UseCases.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<UserResponse> RegisterAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var existing = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existing is not null)
            throw new InvalidOperationException("A user with this email already exists.");

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHashed = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        var created = await _userRepository.CreateAsync(user, cancellationToken);
        return new UserResponse(created.Id, created.Username, created.Email);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHashed))
            throw new UnauthorizedAccessException("Invalid email or password.");

        var token = _tokenService.GenerateToken(user);
        return new LoginResponse(token);
    }
}