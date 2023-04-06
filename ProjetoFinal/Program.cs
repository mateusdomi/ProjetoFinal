using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinal.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjetoFinalContext>(options =>
{
    var conString = builder.Configuration.GetConnectionString("ProjetoFinalContext");
    options.UseSqlServer(conString, opt =>
    {
        opt.MigrationsAssembly(typeof(ProjetoFinalContext).Assembly.FullName.Split(',')[0]);
    });
});

// Add services to the container.

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
