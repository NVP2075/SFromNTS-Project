namespace SFromNTS_Project.Models
{
    public class SignupInfo
    {
        public string AccountName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserSurname {  get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
    }
}
