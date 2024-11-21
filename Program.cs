
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pet_Web_Application_10._12._24_F.Areas.Data;
using Pet_Web_Application_10._12._24_F.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Pet_Web_Application_10._12._24_F.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PuppiesProductPurchasesDbFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PuppiesProductPurchasesDbFContext") ?? throw new InvalidOperationException("Connection string 'PuppiesProductPurchasesDbFContext' not found.")));

builder.Services.AddDbContext<PuppiesandProductPurchasesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PuppiesandProductPurchasesContext") ?? throw new InvalidOperationException("Connection string 'PuppiesandProductPurchasesContext' not found.")));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

// Add session and CartService
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Enable session middleware

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();