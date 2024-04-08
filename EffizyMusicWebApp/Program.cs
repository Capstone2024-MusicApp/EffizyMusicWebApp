using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Services;
using EffizyMusicWebApp.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Add services to the container.
var services = builder.Services;
builder.Services.AddBlazorBootstrap();

// Add your DbContext configuration
builder.Services.AddDbContext<EffizyMusicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EffizyMusicConnection")));

// Register UserService
builder.Services.AddScoped<IUserService, UserService>();

// Register Subscription
builder.Services.AddScoped<SubscriptionService>();

// PayPal Service
builder.Services.AddScoped<PayPalService>();

builder.Services.AddHttpClient<PayPalService>();

// Register UserProfileService
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

// Register EffizyMusicApplicationService
builder.Services.AddScoped<EffizyMusicApplicationService>();

// Register EnrollmentService
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

builder.Services.AddScoped<EnrollmentService>();


// Register CourseService
builder.Services.AddScoped<ICourseService, CourseService>();

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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<ICourseService, CourseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseSession();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
