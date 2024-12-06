using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pet_Web_Application_10._12._24_F.Data;
using Pet_Web_Application_10._12._24_F.Data.Model; // Ensure this namespace is included
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pet_Web_Application_10._12._24_F.Areas.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Register ShoppingCart as a scoped service
builder.Services.AddScoped<ShoppingCart>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();