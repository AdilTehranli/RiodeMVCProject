using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Models;
using RiodeMVCProject.ViewModels.AuthVMs;

namespace RiodeMVCProject.Controllers;

public class AuthController : Controller
{
    readonly UserManager<AppUser> _userManager;
    readonly SignInManager<AppUser> _signInManager;
    readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if(!ModelState.IsValid) return View();
        AppUser appUser = new AppUser()
        {
            UserName=registerVM.UsernameOrEmail,
            
            
        };
        var result = await _userManager.CreateAsync(appUser,registerVM.Password);
        if(!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
                return View();
        }
        return RedirectToAction(nameof(Login));
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid) return View();

        var user = await _userManager.FindByNameAsync(loginVM.UsernameOrEmail);
        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
            if (user == null)
            {
                ModelState.AddModelError("", "Username, email or password is wrong");
                return View();
            }
        }
        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);
        if (result.IsLockedOut)
        {
            ModelState.AddModelError("", "Wait untill " + user.LockoutEnd.Value.AddHours(4).ToString("HH:mm:ss"));
            return View();
        }
        if (!result.Succeeded)
        {

            ModelState.AddModelError("", "Username, email or password is wrong");

            return View();
        }
        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> Signout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
    //public async Task CreateRole()
    //{
    //    await _roleManager.CreateAsync(new IdentityRole{Name = "Admin"}) ;
    //    await _roleManager.CreateAsync(new IdentityRole{Name = "Member"}) ;
    //    await _roleManager.CreateAsync(new IdentityRole{Name = "Editor"});
    //}
}
