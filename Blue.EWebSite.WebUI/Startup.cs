using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.EWebSite.DataAccess.Concrete.EntityFramework;
using Blue.EWebSite.WebUI.Identity;
using Blue.EWebSite.WebUI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blue.EWebSite.WebUI
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlueContext>(options => options.UseSqlServer(_configuration["DbConnection"]));
            services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Security/Login";
                options.AccessDeniedPath = "/Security/AccessDenied";
                options.LogoutPath = "/Security/Logout";
                options.SlidingExpiration = true;

                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                     Name = "Blue.EWbsite.Cookie",
                      Path = "/",
                       SameSite = SameSiteMode.Lax,
                        SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.CustomStaticFiles();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
