using CleanArch.Domain.Models;

namespace CleanArch.Application.Contracts.Infrastructure;

public interface ITokenService
{
    string GenerateToken(User user);
}

