using BCrypt.Net;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Application.Contracts.UseCases.Users;
using CleanArch.Application.DTOs.Users;
using CleanArch.Domain.Models;

namespace CleanArch.Application.UseCases.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHashed = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        var created = await _userRepository.CreateAsync(user, cancellationToken);
        return new UserResponse(created.Id, created.Username, created.Email);
    }

    public async Task<UserResponse> UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null) throw new KeyNotFoundException($"User with id {request.Id} not found.");

        user.Username = request.Username;
        user.Email = request.Email;

        var updated = await _userRepository.Update(user, cancellationToken);
        return new UserResponse(updated.Id, updated.Username, updated.Email);
    }

    public async Task<UserResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user is null) return null;
        return new UserResponse(user.Id, user.Username, user.Email);
    }

    public async Task<UserResponse?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
        if (user is null) return null;
        return new UserResponse(user.Id, user.Username, user.Email);
    }

}