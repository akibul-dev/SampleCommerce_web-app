using Microsoft.EntityFrameworkCore;
using SampleCommerce.DependencyResolve;
using SampleCommerce.Repositories;
using SampleCommerce.Services;
using SampleCommerce.Services.Abstractions;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

AppConfig.ConfigureDependency(builder.Services);

builder.Services.AddAutoMapper(typeof(Program));


//----------------------------------------------
var app = builder.Build();
//-----------------------------------------------

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
