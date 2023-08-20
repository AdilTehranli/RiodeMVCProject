using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Models;
using RiodeMVCProject.ViewModels.UserVMs;
using System.Data;

namespace RiodeMVCProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly RiodeDbContext _context;
        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, RiodeDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
            var res = await _userManager.Users.ToListAsync();
            List<UserAndRolesVM> rolesVMs = new List<UserAndRolesVM>();
            foreach (var user in res)
            {
                var roles = await _userManager.GetRolesAsync(user);
                rolesVMs.Add(new UserAndRolesVM
                {
                    Name = user.UserName,
                    Role = roles.FirstOrDefault()
                });
            }
            ViewBag.Roles= new SelectList(await _roleManager.Roles.ToListAsync(),"Name","Name");
            return View(rolesVMs);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeRole(string username, string role)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity?.Name);
            var user = await _userManager.FindByNameAsync(username);
            if (currentUser == null || user == null) return BadRequest();
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.FirstOrDefault() == "Admin")
            {
                return BadRequest();
            }
            else
            {
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, role);
            }
            return Ok();
        }
    }
}
