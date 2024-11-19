
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pet_Web_Application_10._12._24_F.Areas.Data;
using Pet_Web_Application_10._12._24_F.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PuppiesProductPurchasesDbFContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("PuppiesProductPurchasesDbFContext") ?? throw new InvalidOperationException("Connection string 'PuppiesProductPurchasesDbFContext' not found.")));

builder.Services.AddDbContext<PuppiesandProductPurchasesContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("PuppiesandProductPurchasesContext") ?? throw new InvalidOperationException("Connection string 'PuppiesandProductPurchasesContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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
app.MapRazorPages();

app.Run();

