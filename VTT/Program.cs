using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VTT.Data;
using VTT.Services.Repositories;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.AspNetCore.Identity;
using VTT.Services.Users;
using VTT.Services.Characters;
using VTT.Models.Entities;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Singleton);

builder.Services.AddTransient<IRepositoryBase<Character>, RepositoryBase<Character>>();
builder.Services.AddTransient<IRepositoryBase<User>, RepositoryBase<User>>(); 
builder.Services.AddTransient<IRepositoryBase<World>, RepositoryBase<World>>();

builder.Services.AddSingleton<ICharacterService, CharacterService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IWorldService, WorldService>();



var app = builder.Build();

var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
    .BuildServiceProvider();

var _AppDbContext = serviceProvider.GetService<AppDbContext>();
_AppDbContext.Database.EnsureDeleted();
_AppDbContext.Database.EnsureCreated();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
