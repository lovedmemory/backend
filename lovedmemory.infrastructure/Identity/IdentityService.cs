﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using lovedmemory.Application.Common.Interfaces;
using lovedmemory.Application.Common.Models;

namespace lovedmemory.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<AppUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<AppUser> userManager,
        IUserClaimsPrincipalFactory<AppUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result<bool> Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new AppUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            return (Result<bool>.Success(true), user.Id);
        }
        else
        {
            // If user creation failed, you might want to log the errors or handle them appropriately.
            // This example assumes a simple Result<bool> class.

            return (Result<bool>.Failure(result.Errors.Select(error => error.Description).ToList()), null);

        }
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : true;
    }

    public async Task<bool> DeleteUserAsync(AppUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.Succeeded;
    }

    Task<Result<bool>> IIdentityService.DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}