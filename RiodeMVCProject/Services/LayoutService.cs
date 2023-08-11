using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;

namespace RiodeMVCProject.Services;

public class LayoutService
{
    readonly RiodeDbContext _context;

    public LayoutService(RiodeDbContext context)
    {
        _context = context;
    }
    public async Task<Dictionary<string, string>> GetSettings()
 => await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
}
