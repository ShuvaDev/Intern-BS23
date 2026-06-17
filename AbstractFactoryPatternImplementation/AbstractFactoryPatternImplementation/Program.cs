using Core.Contracts.Factories;
using Infrastructure.Factories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IThemeFactory, DarkThemeFactory>();
//builder.Services.AddScoped<IThemeFactory, LightThemeFactory>();

var app = builder.Build();


app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
