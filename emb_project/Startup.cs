using Core.Service;
using DataLayer.Context;
using emb_project.Interface;
using emb_project.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb_project
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
            #region AddScope
            services.AddScoped<IAdmin, AdminService>();
            services.AddScoped<IUser, UserService>();
            #endregion
            #region DbContext
            services.AddDbContext<DataBaseDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            });
            #endregion
            #region Service
            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();

            //for area
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "AdminPanel",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
             
            });
        }
    }
}
