using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace lovedmemory.application.DTOs
{
    public class LoginDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
    public class AppUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }
    }
        public class RegisterDto
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        public string? Othername { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }

}
