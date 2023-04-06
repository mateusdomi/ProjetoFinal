using Microsoft.EntityFrameworkCore;
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

builder.Services.AddScoped<SeedingService>();
// Add services to the container.

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    seedDb();
}
else
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

void seedDb()
{
    using (var scoped = app.Services.CreateScope())
    {
        var dbinitializer = scoped.ServiceProvider.GetRequiredService<SeedingService>();
        dbinitializer.Seed();

    }
};
