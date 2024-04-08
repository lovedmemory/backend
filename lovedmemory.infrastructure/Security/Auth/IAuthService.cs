using lovedmemory.application.DTOs;
namespace lovedmemory.infrastructure.Security.Auth;

public interface IAuthService
{
    Task<string> Register(RegisterDto request);
    Task<string> Login(LoginDto request);
}
