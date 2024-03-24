using Microsoft.AspNetCore.Identity;

namespace lovedmemory.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string UserName { get; set; }
}
