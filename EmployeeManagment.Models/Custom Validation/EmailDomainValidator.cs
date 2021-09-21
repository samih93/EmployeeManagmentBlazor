using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Custom_Validation
{
    public class EmailDomainValidator :ValidationAttribute
    {
        public string AllowDomain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                string[] strings = value.ToString().Split('@');

                if (strings.Length > 1 && strings[1].ToUpper() == AllowDomain.ToUpper())
                {
                    return null;
                }
            }
           
            
               

            return new ValidationResult($"domain must be {AllowDomain}", new[] { validationContext.MemberName});
        }
    }
}
