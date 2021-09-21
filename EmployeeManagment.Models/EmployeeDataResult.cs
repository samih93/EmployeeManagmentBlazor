using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeDataResult
    {
        public IEnumerable<Employee> Employees { get; set; }
        public int Count { get; set; }
    }
}
