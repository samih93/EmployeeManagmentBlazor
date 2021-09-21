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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }

        [HttpGet]
        public async  Task<ActionResult> GetDepartments() {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int departmentId)
        {
            try
            {
                var result = await departmentRepository.GetDepartment(departmentId);
                if (result == null)
                {
                    return NotFound();
                }
                return  result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the database ");
            }
        }

    }
}
