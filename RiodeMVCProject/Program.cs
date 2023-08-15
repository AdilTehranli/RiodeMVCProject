using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddService();
// Add services to the container.


builder.Services.AddDbContext<RiodeDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:MSSQL"]);

});
builder.Services.AddControllersWithViews();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
