using System.ComponentModel.DataAnnotations;

namespace SFromNTS_Project.Models
{
    public class LoginInfo
    {
        [Required]
        public string AccountName { get; set; } = null!;
        [Required]
        [MinLength(6, ErrorMessage = "Mật khẩu phải nhiều hơn 6 kí tự!")]
        public string Password { get; set; } = null!;
    }
}
