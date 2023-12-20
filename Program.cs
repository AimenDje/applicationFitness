using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuiviFitness.Models;
using SuiviFitness.Services;
using SuiviFitness.Settings;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration de la cha�ne de connexion � partir de appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// pour une base des donn�es Sql Server
var connectionString = configuration.GetConnectionString("LocalSqlServerConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("TwilioSettings"));

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId =  builder.Configuration.GetSection("GoogleAuthSettings").GetValue<string>("ClientId");
    googleOptions.ClientSecret = builder.Configuration.GetSection("GoogleAuthSettings").GetValue<string>("ClientSecret");
});

builder.Services.AddScoped<ISMSSenderService, SMSSenderService>();



builder.Services.AddRazorPages();


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

app.MapRazorPages();

app.Run();
