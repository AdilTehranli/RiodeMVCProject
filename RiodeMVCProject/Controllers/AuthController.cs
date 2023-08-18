using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Models;
using RiodeMVCProject.ViewModels.AuthVMs;

namespace RiodeMVCProject.Controllers;

public class AuthController : Controller
{
    readonly UserManager<AppUser> _userManager;

    public AuthController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
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
}
