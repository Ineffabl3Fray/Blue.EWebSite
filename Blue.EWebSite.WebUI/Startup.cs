using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.EWebSite.Business.Abstract;
using Blue.EWebSite.Business.Concrete.EntityFramework;
using Blue.EWebSite.DataAccess.Abstract;
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
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            services.AddDistributedMemoryCache();


            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, CategoryDal>();

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConntection")));
            services.AddIdentity<AppIdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
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
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
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

            app.UseSession();

            app.CustomStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("prooductDetail", "{controller=Home}/{action=Detail}/{id?}");

                endpoints.MapControllerRoute("adminProducts", "{controller=Admin}/{action=Edit}/{id?}");

            });
        }
    }
}
