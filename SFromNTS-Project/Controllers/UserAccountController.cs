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
        public IActionResult SignUp([FromBody]SignupInfo sUI )
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Vui lòng điền đầy đủ thông tin!" });
            var isExist = _context.UserAccounts.Any(u => u.Email == sUI.Email);
            if (isExist)
            {
                return Json(new { success = false, message = "Email này đã có tài khoản, vui lòng đăng nhập lại!" });
            }


            UserAccount newUC = new UserAccount(); 
            newUC.AccountName = sUI.AccountName;
            newUC.HashedPassword = BCrypt.Net.BCrypt.HashPassword(sUI.Password);
            newUC.CreateDate = DateTime.Now;
            newUC.Email = sUI.Email;
            newUC.AccountStatus = true;


            _context.Add(newUC);
            _context.SaveChanges();
            return Json(new { success = true });
        }
      
    }
}
