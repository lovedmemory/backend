using lovedmemory.Infrastructure.Identity;

namespace lovedmemory.infrastructure.Identity
{
    public class UserDto
    {
        public AppUser User { get; set; }
        public string AccessToken { get; set; }
    }
}
