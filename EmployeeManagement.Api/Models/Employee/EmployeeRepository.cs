using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IDepartmentRepository _departmentRepository;
        public EmployeeRepository(AppDbContext _appDbContext , IDepartmentRepository departmentRepository)
        {
            this.appDbContext = _appDbContext;
            _departmentRepository = departmentRepository;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee.DepartmentId == 0)
            {
                throw new Exception("Employee DepartmentId cannot be ZERO");
            }
            else
            {
                Department department = await this._departmentRepository.GetDepartment(employee.DepartmentId);
                if (department == null)
                {
                    throw new Exception($"Invalid Employee DepartmentId {employee.DepartmentId}");
                }
                employee.Department = department;
            }
            employee.Photopath = "samih.jpg";

            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees.Include(d => d.Department).FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<EmployeeDataResult> GetEmployees(int skip = 0, int take = 5)
        {
            EmployeeDataResult employeeDataResult = new EmployeeDataResult
            {
                Employees = appDbContext.Employees.Include(d => d.Department).Skip(skip).Take(5).ToList(),
                Count = await appDbContext.Employees.CountAsync()
            };
             return employeeDataResult;

        }

        public async  Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await  appDbContext.Employees.Include(d => d.Department).OrderBy(i=>i.Id).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> employees = appDbContext.Employees;

            if (name != null)
            {
                employees = employees.Where(e => e.Name.Contains(name));
            }
            if (gender != null)
            {
                employees = employees.Where(e => e.Gender == gender);
            }
            return await employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (result != null)
            {
                result.Name = employee.Name;
                result.DepartmentId = employee.DepartmentId;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.Photopath = employee.Photopath;
                result.BirthDate = employee.BirthDate;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
