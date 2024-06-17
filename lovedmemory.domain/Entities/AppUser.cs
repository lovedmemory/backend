
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace lovedmemory.domain.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? OtherName { get; set; }
    public string? NickName { get; set; }
    [NotMapped]
    public string FullName
    {
        get
        {
            if (string.IsNullOrEmpty(LastName))
                return FirstName;
            else
                return $"{FirstName} {LastName}";
        }
    }

}
