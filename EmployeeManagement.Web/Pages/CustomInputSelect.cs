using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    // to use int in bind in input select cz input select does not support int32 
    public class CustomInputSelect<Tvalue> :InputSelect<Tvalue>
    {
        protected override bool TryParseValueFromString(string value, out Tvalue result,out string validationErrorMessage)
        {
            if (typeof(Tvalue) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (Tvalue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"The selected value {value} is not valid number";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}
