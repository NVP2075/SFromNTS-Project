using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SFromNTS_Project.Models
{
    public class SignupInfo
    {
        [Required(ErrorMessage ="Vui lòng điền tên tài khoản!")]
        public string AccountName { get; set; } = null!;
        [Required(ErrorMessage ="Vui lòng điền mật khẩu!")]
        [MinLength(6, ErrorMessage ="Mật khẩu phải có ít nhất 6 kí tự")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage ="Vui lòng điền email!")]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage ="Vui lòng điền tên của bạn!")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage ="Vui lòng điền họ của bạn!")]
        public string UserSurname {  get; set; } = null!;
        [Required(ErrorMessage ="Vui lòng thêm ngày sinh!")]
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
    }
}
