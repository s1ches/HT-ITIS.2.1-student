// dotcover disable

using System.Diagnostics.CodeAnalysis;
using WebApplication1.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services
    .AddMathCalculator()
    .AddCachedMathCalculator();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Index}/{id?}");
app.Run();

namespace WebApplication1
{
    [ExcludeFromCodeCoverage]
    public partial class Program { }
}