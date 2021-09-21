using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<EmployeeDataResult> GetEmployees(int skip , int take);
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> CreateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
