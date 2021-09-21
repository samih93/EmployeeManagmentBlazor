using EmployeeManagement.Web.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase :ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public string  Coordinates { get; set; }

        public string ButtonText { get; set; } = "Show Footer";
        public string cssclass { get; set; } = "HideFooter";

        public Employee employee { get; set; } = new Employee();

        [Parameter]
        public string  Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        protected void MouseMove(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX} Y={e.ClientY} ";
        }

        protected void Button_Click() {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                cssclass = "HideFooter";
            }
            else
            {
                ButtonText = "Hide Footer";
                cssclass = null;
            }
        }
    }
}
