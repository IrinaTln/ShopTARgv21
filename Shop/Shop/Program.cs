using Microsoft.EntityFrameworkCore;
using ShopTARgv21.ApplicationServices.Services;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISpaceShipServices, SpaceShipServices>();

builder.Services.AddScoped<ICarServices, CarServices>();

builder.Services.AddScoped<IFileServices, FileServices>();

builder.Services.AddScoped<IRealEstateServices, RealEstateServices>();

builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();

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
