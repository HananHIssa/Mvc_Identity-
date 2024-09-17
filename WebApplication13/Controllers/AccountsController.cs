using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Data;
using WebApplication13.Models.ViewModel;

namespace WebApplication13.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModelcs r)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = r.Email,
                PhoneNumber = r.phoneNumber,
                UserName = r.Email // UserName is required in IdentityUser, set it to Email if not provided separately
            };

            var result = await _userManager.CreateAsync(user, r.password);

            if (result.Succeeded)
            {
                return RedirectToAction("LogIn");
            }

            return View(r);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModelcs c)
        {
            var result = await _signInManager.PasswordSignInAsync(c.email, c.password, c.remberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(c);
        }
    }
}
