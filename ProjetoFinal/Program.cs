using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Infra;
using ProjetoFinal.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("C:\\Users\\lucas\\Desktop\\ProjetoFinal\\Infra\\Logs\\Logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
builder.Logging.AddSerilog(_logger);

builder.Services.AddDbContext<ProjetoFinalContext>(options =>
{
    var conString = builder.Configuration.GetConnectionString("ProjetoFinalContext");
    options.UseSqlServer(conString, opt =>
    {
        opt.MigrationsAssembly(typeof(ProjetoFinalContext).Assembly.FullName.Split(',')[0]);
    });
});

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<IHistoricoService, HistoricoService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IMensagemService, MensagemService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<ISerieService, SerieService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
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
