using java.io;
using LabWork.Data;
using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using LabWork.Helper;
using LabWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LabWork.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContent appDBContent;
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDBContent appDBContent, SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.appDBContent = appDBContent;
            this._userManager = userManager;
            this._signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded) return RedirectToAction("List", "Games");
                ModelState.AddModelError("", "Неправильний логін чи пароль! Спробуйте ще раз");
            }
            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Helper.Manager));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Helper.Customer));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var existUser = await _userManager.FindByEmailAsync(model.Email);
            if (existUser != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(existUser);
                var result = await _userManager.ResetPasswordAsync(existUser, token, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(existUser, isPersistent: false);
                    return RedirectToAction("List", "Games");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            } 
            else
            {
                var user = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.Email,
                    Email = model.Email,
                    Role = "Customer"
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Helper.Helper.Customer);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("List", "Games");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
