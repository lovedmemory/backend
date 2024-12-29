using lovedmemory.domain.Entities;

namespace lovedmemory.Infrastructure.Security.TokenGenerator;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(AppUser user, IEnumerable<string> userRoles);
}