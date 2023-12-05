
using DryCleanerAppBussinessLogic;
using DryCleanerAppBussinessLogic.Implementation;
using DryCleanerAppBussinessLogic.Interfaces;
using DryCleanerAppDataAccess.IRepository;
using DryCleanerAppDataAccess.Repository;
using DryCleanerAppDataAccess.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

string? dbConnectionString = builder.Configuration.GetConnectionString("AppConnection");

builder.Services.AddDbContext<DryCleanerContext>(options =>
options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString))
);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = "DryCleaner",
        ValidIssuer = "DryCleaner",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSignInKey"]))

    };
});
builder.Services.AddRepositoryDependecies();
builder.Services.AddScoped<ICompanyB, CompanyB>();
builder.Services.AddScoped<IUserB, UserB>();
builder.Services.AddScoped<ISecurityB, SecurityB>();
builder.Services.AddHttpClient();
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
app.UseAuthentication();//this checks the user is valid
app.UseAuthorization();//this checks user has valid roles

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
