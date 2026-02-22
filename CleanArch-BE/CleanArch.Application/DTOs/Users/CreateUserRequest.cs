using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs.Users;

public record CreateUserRequest(
    [Required][MaxLength(50)] string Username,
    [Required][EmailAddress][MaxLength(255)] string Email,
    [Required][MinLength(6)] string Password
);