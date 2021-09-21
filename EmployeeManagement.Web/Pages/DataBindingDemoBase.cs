using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DataBindingDemoBase :ComponentBase
    {
        public string Name { get; set; } = "Tom";
        public string Gendar { get; set; } = "Male";
        public string color { get; set; } = "background-color: white";

        public string Description { get; set; } = "";
        public void Onchange_event(ChangeEventArgs e)
        {
            Name = e.Value.ToString() ;
        }

      
    }
}
