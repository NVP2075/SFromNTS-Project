using Microsoft.AspNetCore.Mvc;
using SFromNTS_Project.Models;

namespace SFromNTS_Project.Controllers
{
    public class UserAccountController : Controller
    {
        private SfromNtsProjectContext _context;
        public UserAccountController(SfromNtsProjectContext context)
        {
            _context = context;
        }
        public IActionResult LoginAndSignupForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp([FromBody] SignupInfo sUI) //Nên tạo transaction để trainning
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Vui lòng điền đầy đủ thông tin!(ac)" });
            var emailIsExist = _context.UserAccounts.Any(u => u.Email == sUI.Email);
            var accountNameIsExist = _context.UserAccounts.Any(u => u.AccountName == sUI.AccountName);
            if (accountNameIsExist)
                return Json(new { success = false, message = "Tên tài khoản này đã tồn tại, vui lòng đăng nhập lại!" });
            if (emailIsExist)
                return Json(new { success = false, message = "Email này đã có tài khoản, vui lòng đăng nhập lại!" });



            UserAccount newUC = new UserAccount();
            newUC.UserId = Guid.NewGuid();
            newUC.AccountName = sUI.AccountName;
            newUC.HashedPassword = BCrypt.Net.BCrypt.HashPassword(sUI.Password);
            newUC.CreateDate = DateTime.Now;
            newUC.Email = sUI.Email;
            newUC.AccountStatus = true;

            UserInformation newUI = new UserInformation();
            newUI.UserId = newUC.UserId;
            newUI.UserName = sUI.UserName;
            newUI.UserSurname = sUI.UserSurname;
            newUI.DateOfBirth = sUI.DateOfBirth;
            newUI.Occupation = sUI.Occupation;

            _context.Add(newUC);
            _context.Add(newUI);
            _context.SaveChanges();
            return Json(new { success = true, message = "Đăng ký thành công!" });
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginInfo userAcc)
        {
            UserAccount uc = _context.UserAccounts.FirstOrDefault(u => u.AccountName == userAcc.AccountName);
            if (uc != null)
            {
                bool pass = BCrypt.Net.BCrypt.Verify(userAcc.Password, uc.HashedPassword);
                if (pass)
                    return Json(new { success = true, message = "Đăng nhập thành công" });
                else
                    return Json(new { success = false, message = "Mật khẩu không chính xác!" });
            }
            return Json(new { success = false, message = "Tên đăng nhập không tồn tại!" });
        }

    }
}
