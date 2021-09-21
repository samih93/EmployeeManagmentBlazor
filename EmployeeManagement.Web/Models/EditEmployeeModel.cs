using EmployeeManagement.Models;
using EmployeeManagement.Models.Custom_Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        [MinLength(2)]
        public string Name { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowDomain = "hotmail.com")]
        public string Email { get; set; }
        [CompareProperty("Email" ,ErrorMessage ="Email and confirm Email  must match")]
        public string ConfirmEmail { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
        public string Photopath { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
