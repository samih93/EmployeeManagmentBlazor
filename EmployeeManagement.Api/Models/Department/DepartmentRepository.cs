using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext _appDbContext)
        {
            this.appDbContext = _appDbContext;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDbContext.Departments.FirstOrDefaultAsync(e => e.Id == departmentId);

        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }
    }
}
