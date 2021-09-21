using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees(int skip = 0, int take = 5)
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees(skip, take));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }
        }
        [HttpGet("all")]
        public  async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetAllEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }
        }


        [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
               var Employees = await employeeRepository.Search(name, gender);
                if (Employees.Any())
                {
                    return Ok(Employees);
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var CreatedEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = CreatedEmployee.Id }, CreatedEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }

        }
        [HttpPut()]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                var EmployeeToUpdate = await employeeRepository.GetEmployee(employee.Id);
                if (EmployeeToUpdate == null)
                {
                    return NotFound($"Employee with Id ={employee.Id} not Found");
                }
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var EmployeeToDelete = await employeeRepository.GetEmployee(id);
                if (EmployeeToDelete == null)
                {
                    return NotFound($"Employee with Id ={id} not Found");
                }

                return await employeeRepository.DeleteEmployee(id);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }
        }

    }
}
