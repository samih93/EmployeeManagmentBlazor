using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public  async Task<EmployeeDataResult> GetEmployees(int skip ,int take)
        {
            return await httpClient.GetJsonAsync<EmployeeDataResult>($"api/employees?skip={skip}&take={take}");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await httpClient.GetJsonAsync<Employee[]>($"api/employees/all");
        }


        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await httpClient.PutJsonAsync<Employee>($"api/employees",employee);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await httpClient.PostJsonAsync<Employee>($"api/employees", employee);

        }

        public async Task DeleteEmployee(int id)
        {
             await httpClient.DeleteAsync($"api/employees/{id}");
        }
    }
}
