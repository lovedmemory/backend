using Microsoft.AspNetCore.Identity;
using lovedmemory.Application.Common.Models;
using lovedmemory.Infrastructure.Identity;

namespace lovedmemory.Application.Identity;

public static class IdentityResultExtensions
{
    //public static Result<SchoolUser> ToApplicationResult(this IdentityResult result)
    //{
    //    return result.Succeeded
    //        ? Result<SchoolUser>.Success()
    //        : Result<SchoolUser>.Failure(result.Errors.Select(e => e.Description));
    //}

}
