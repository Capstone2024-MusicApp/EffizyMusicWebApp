using Blazored.SessionStorage;
using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Services;
using EffizyMusicWebApp.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
DotNetEnv.Env.Load(".sendgrid.env");

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazoredSessionStorage();

// Add your DbContext configuration
builder.Services.AddDbContext<EffizyMusicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EffizyMusicConnection")));

// Register your services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<SubscriptionService>();
builder.Services.AddScoped<PayPalService>();
builder.Services.AddHttpClient<PayPalService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<EffizyMusicApplicationService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddScoped<CourseService>();

// Register UserTypeService
builder.Services.AddScoped<UserTypeService>();

// Register UserInstrumentService
builder.Services.AddScoped<InstrumentService>();
builder.Services.AddScoped<EffizyMusicApplicationService>();
builder.Services.AddScoped<CourseService>();

builder.Services.AddScoped<UserTypeService>();
builder.Services.AddScoped<InstrumentService>();
builder.Services.AddScoped<IEffizyMusicApplicationService, EffizyMusicApplicationService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();

var app = builder.Build();

// Retrieve the API key from the environment variable
var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
