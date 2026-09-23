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
      
    }
}
