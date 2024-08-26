using Application.Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Infrastructure.Services;

public class IdentityService(IHttpContextAccessor context) : IIdentityService
{
    public Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        throw new NotImplementedException();
    }

    public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public string GetUserIdentity()
        => context.HttpContext?.User.FindFirst("sub")?.Value;

    public string GetUserName()
        => context.HttpContext?.User.Identity?.Name;

    public Task<string> GetUserNameAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(string userId, string role)
    {
        throw new NotImplementedException();
    }
}
