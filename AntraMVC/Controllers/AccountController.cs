using AntraMVC.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AntraMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register obj)
        {
            var result = new IdentityUser
            {
                UserName = obj.UserName,
                Email = obj.Email,
            };
            await _userManager.CreateAsync(result, obj.Password);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login obj)
        {
            //var result = await _signInManager.PasswordSignInAsync(obj.UserName, obj.Password, false, false);

            //return RedirectToAction("Index", "Home");


            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(obj.UserName, obj.Password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View();

            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
