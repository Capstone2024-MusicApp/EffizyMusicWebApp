using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Services;
using EffizyMusicWebApp.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicWebApi.Services;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EffizyMusicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr") ?? throw new InvalidOperationException("Connection string 'ConnStr' not found.")));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7106/") });

builder.Services.AddHttpClient();

//builder.Services.AddTransient<ModuleManager>();
//builder.Services.AddTransient<QuizManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
