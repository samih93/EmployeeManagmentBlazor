using EmployeeManagement.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeAdapter :DataAdaptor
    {
        private readonly IEmployeeService _employeeService1;
        public EmployeeAdapter(IEmployeeService employeeService)
        {
            _employeeService1 = employeeService;
        }
        public async override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            EmployeeDataResult emploeyeeDataResult= await _employeeService1.GetEmployees(dataManagerRequest.Skip, dataManagerRequest.Take);
            DataResult dataResult = new DataResult
            {
                Result = emploeyeeDataResult.Employees,
                Count = emploeyeeDataResult.Count

            };
            return dataResult;
        }
    }
}
