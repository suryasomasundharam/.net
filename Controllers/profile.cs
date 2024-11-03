using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using newproject2.EmployeeDBContext;
using newproject2.Models;
namespace newproject2.Controllers
{
    public class profile : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly EmployeeDetailsDBContext _context;
        public profile( EmployeeDetailsDBContext context)
        {
 
            _context = context;
        }

        public async Task<IActionResult> Index(string username)
        {
            var user = await _context.login.FindAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}
