using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingManager.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using AutoMapper;
using MediatR;
using BuildingManager.Repositories;

namespace BuildingManager
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
            //Add Identity
            services.AddIdentity<BuildingUser, BuildingUserRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<IdentityContext>();

            ////Add LocalDB
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ActivityContext")));

            //Add FluentValidation
            services.AddMvc()
                .AddFluentValidation(f =>
                    f.RegisterValidatorsFromAssemblyContaining<Startup>());

            //Add Automapper
            services.AddAutoMapper(typeof(Startup));

            //AddRepositories
            services.AddScoped<IBuildingActivityRepository, BuildingActivityRepository>();
            services.AddScoped<IBuildingUserRepository, BuildingUserRepository>();

            //AddMediatr,
            //var assembly = AppDomain.CurrentDomain.Load("BuildingManager");
            services.AddMediatR(typeof(Startup));
            //services.AddMediatR(assembly);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    pattern: "{controller=BuildingActivities}/{action=Index}/{id?}");
            });
        }
    }
}
