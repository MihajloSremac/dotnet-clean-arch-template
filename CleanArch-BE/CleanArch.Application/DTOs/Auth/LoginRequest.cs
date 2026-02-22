using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs.Auth;

public record LoginRequest(
    [Required][EmailAddress] string Email,
    [Required] string Password
);