using Microsoft.EntityFrameworkCore;
using MusicWebApi.Data;
using MusicWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EffizyMusicDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr") ?? throw new InvalidOperationException("Connection string 'ConnStr' not found.")));

builder.Services.AddControllers();
builder.Services.AddTransient<ModuleManager>();
builder.Services.AddTransient<QuizManager>();
builder.Services.AddTransient<QuestionsManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
