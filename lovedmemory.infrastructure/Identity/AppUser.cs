using Microsoft.AspNetCore.Identity;

namespace lovedmemory.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? OtherName { get; set; }
    public string? NickName { get; set; }

}
