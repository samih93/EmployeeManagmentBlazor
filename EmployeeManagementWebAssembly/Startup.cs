
using EmployeeManagementWebAssembly.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
           
            // need to inject IEmployeeService in base class to get data from api 
            services.AddHttpClient<IEmployeeService, EmployeeService>(client=> client.BaseAddress = new Uri("https://localhost:44315/"));


            services.AddHttpClient<IDepartmentService, DepartmentService>(client=> client.BaseAddress = new Uri("https://localhost:44315/"));



         
        }

      
    }
}
