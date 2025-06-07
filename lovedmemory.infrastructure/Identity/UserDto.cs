using lovedmemory.application.DTOs;

namespace lovedmemory.infrastructure.Identity
{
    public class UserDto
    {
        public AppUserDto User { get; set; }
        public string Token { get; set; }
    }
}
