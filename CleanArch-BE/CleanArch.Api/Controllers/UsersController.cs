using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Application.Contracts.UseCases.Users;
using CleanArch.Application.DTOs.Users;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // all endpoints require a valid JWT by default
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [AllowAnonymous] // creating a user is public — no token needed
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateAsync(request, cancellationToken);
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        if (currentUserId != request.Id)
            return Forbid();

        var user = await _userService.UpdateAsync(request, cancellationToken);
        return Ok(user);
    }
}
