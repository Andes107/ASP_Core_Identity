using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Identity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Identity.IdentityPolicy;
using System;
using Microsoft.AspNetCore.Authorization;
using Identity.CustomPolicy;

namespace Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordPolicy>();
            services.AddTransient<IUserValidator<AppUser>, CustomUsernameEmailPolicy>();
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthorizationHandler, AllowUsersHandler>();
            services.AddAuthorization(opts => {
                opts.AddPolicy("AllowTom", policy => {
                    policy.AddRequirements(new AllowUserPolicy("tom"));
                });
            });

            services.Configure<IdentityOptions>(opts => {
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNetCore.Identity.Application";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });
            services.AddAuthorization(opts => {
                opts.AddPolicy("AspManager", policy => {
                    policy.RequireRole("Manager");
                    policy.RequireClaim("Coding Skill", "ASP.NET Core MVC");
                });
            });
            services.AddAuthentication()
                    .AddGoogle(opts =>
                    {
                        opts.ClientId = "525716261806-8p3ub2j5487jnb4hmj8i3u8ia1m2fk9i.apps.googleusercontent.com";
                        opts.ClientSecret = "awisxb_zvhLE3RXujUss_-Pq";
                        opts.SignInScheme = IdentityConstants.ExternalScheme;
                    });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}