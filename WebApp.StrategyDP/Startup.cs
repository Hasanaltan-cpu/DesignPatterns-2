using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.StrategyDP.Enums;
using WebApp.StrategyDP.Models;
using WebApp.StrategyDP.Repositories;

namespace BaseProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();


            services.AddScoped<IProductRepository>(sp =>
            {

                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();


                var claim = httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == Settings.claimDatabaseType).FirstOrDefault();

                var context = sp.GetRequiredService<AppIdentityDbContext>();

                if (claim == null) return new ProductRepositoryFromSqlServer(context);

                var databaseType = (EDatabaseType)int.Parse(claim.Value);

                return databaseType switch
                {
                    EDatabaseType.SqlServer => new ProductRepositoryFromSqlServer(context),
                    EDatabaseType.MongoDb => new ProductRepositoryFromMongoDb(Configuration),
                    _ => throw new NotImplementedException()
                };




             }

            );
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
