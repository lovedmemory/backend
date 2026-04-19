using lovedmemory.application.Common.Models;
using lovedmemory.application.DTOs;
namespace lovedmemory.Infrastructure.Security.Auth;

public interface IAuthService
{
    Task<UserDto> Login(LoginDto request);
    Task<Result<UserDto>> Register(RegisterDto request);
}
