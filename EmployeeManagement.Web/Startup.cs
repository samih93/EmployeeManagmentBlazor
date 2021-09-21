using EmployeeManagement.Api.Models;
using EmployeeManagement.Web.Data;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSyncfusionBlazor();
            services.AddScoped<EmployeeAdapter>();
            // for login
             services.AddAuthentication("Idenitity.Application").AddCookie();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores <EmployeeManagementWebContext>();

            /////////////////////

            // need to inject IEmployeeService in base class to get data from api 
            services.AddHttpClient<IEmployeeService, EmployeeService>(client=> client.BaseAddress = new Uri("https://localhost:44315/"));


            services.AddHttpClient<IDepartmentService, DepartmentService>(client=> client.BaseAddress = new Uri("https://localhost:44315/"));



            // used for map Employee to Edit Employee
            services.AddAutoMapper(typeof(EmployeeProfile));


            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            /// for login
            app.UseAuthentication();
            app.UseAuthorization();
            /////////////

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
