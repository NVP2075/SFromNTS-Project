using System.ComponentModel.DataAnnotations;

namespace SFromNTS_Project.Models
{
    public class SignupInfo
    {
        [Required]
        public string AccountName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string UserSurname {  get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Occupation { get; set; }
    }
}
