using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs.Users;

public record UpdateUserRequest(
    [Required] int Id,
    [Required][MaxLength(50)] string Username,
    [Required][EmailAddress][MaxLength(255)] string Email
);