using lovedmemory.application.DTOs;
using lovedmemory.infrastructure.Identity;
namespace lovedmemory.infrastructure.Security.Auth;

public interface IAuthService
{
    Task<UserDto> Register(RegisterDto request);
    Task<UserDto> Login(LoginDto request);
}
