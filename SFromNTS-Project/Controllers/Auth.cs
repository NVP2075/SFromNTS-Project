using Microsoft.AspNetCore.Mvc;
using SFromNTS_Project.Models;

namespace SFromNTS_Project.Controllers
{
    public class Auth : Controller
    {
        private SfromNtsProjectContext _context;
        public Auth(SfromNtsProjectContext context)
        {
            _context = context;
        }
        public IActionResult AuthForm()
        {
            return View();
        }
    }
}
