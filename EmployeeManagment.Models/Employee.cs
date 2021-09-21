using EmployeeManagement.Models.Custom_Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        [MinLength(2)]
        public string Name { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowDomain = "hotmail.com")]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        // cz department name is required if 
        public Department Department { get; set; }
        public string  Photopath { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
