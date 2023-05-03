using FinalV4.Data;
using FinalV4.Models;
using FinalV4.services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
namespace FinalV4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<IUserRepo, UserRepositotry>();
            builder.Services.AddScoped<IHotelRepo, HotelRepository>();
            builder.Services.AddScoped<IFlightRepo, FlightRepository>();
            builder.Services.AddScoped<ICityRepo, CityRepository>();
            builder.Services.AddScoped<IBookRepo, BookTicketRepository>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultUI()
                 .AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllersWithViews();

            // Add distributed memory cache
            builder.Services.AddDistributedMemoryCache();

            // Add session support
            builder.Services.AddSession(options =>
            {
                // Set a short timeout for testing purposes
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            StripeConfiguration.ApiKey = "sk_test_51MqaHKDQgx9Zy6bY9Ybc9H3tgInshp2mkKpE6n810dfDu6YTYnYKJFcLttoNhVi72XnrImMTLfdIpE2NpmFmWDNK00WyxM27Uv";



            var app = builder.Build();
            app.UseSession();
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
			app.UseMiddleware<AppRestartMiddleware>();
			app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();



            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                MySeedData.Initialize(context);
            }
			
			app.Run();
           
        }
    }



    public class AppRestartMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppRestartMiddleware> _logger;
        private DateTime _lastRestartTime;

        public AppRestartMiddleware(RequestDelegate next, ILogger<AppRestartMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _lastRestartTime = DateTime.UtcNow;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_lastRestartTime < System.IO.File.GetLastWriteTimeUtc(typeof(Program).Assembly.Location))
            {
                _logger.LogInformation("App restart detected. Logging out user.");
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            await _next(context);
        }
    }
}