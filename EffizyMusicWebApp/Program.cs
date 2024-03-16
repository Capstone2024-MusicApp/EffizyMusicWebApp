using EffizyMusicSystem.Controllers;
using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Services;
using EffizyMusicWebApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EffizyMusicSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();


// Add services to the container.
var services = builder.Services;

// Add your DbContext configuration
services.AddDbContext<EffizyMusicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EffizyMusicConnection")));

// Register UserService
builder.Services.AddScoped<IUserService, UserService>();

// Register ICourseService
builder.Services.AddScoped<ICourseService, CourseService>();

// Register UserTypeService
builder.Services.AddScoped<UserTypeService>();

// Register UserInstrumentService
builder.Services.AddScoped<InstrumentService>();
// Register EffizyMusicApplicationService
builder.Services.AddScoped<IEffizyMusicApplicationService, EffizyMusicApplicationService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
