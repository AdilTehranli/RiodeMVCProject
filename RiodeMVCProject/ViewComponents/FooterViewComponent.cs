using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;

namespace RiodeMVCProject.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        readonly RiodeDbContext _context;

        public FooterViewComponent(RiodeDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Settings.ToDictionaryAsync(p=>p.Key,p=>p.Value));
        }
    }
}
