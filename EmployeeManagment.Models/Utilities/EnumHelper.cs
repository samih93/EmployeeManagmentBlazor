using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Utilities
{
    public class EnumHelper
    {
        public static List<DropDownListItem> EnumToDropDown<T>(string InitialText , string InitialValue)
        {
            List<DropDownListItem> ret = new List<DropDownListItem>();
            var value = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            if (!String.IsNullOrEmpty(InitialText) || !String.IsNullOrEmpty(InitialValue))
            {
                DropDownListItem ddlInitial = new DropDownListItem()
                {
                    Text = InitialText,
                    Value = InitialValue
                };
                ret.Add(ddlInitial);
            }
            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
            {
                DropDownListItem ddlitem = new DropDownListItem();
                ddlitem.Text = Enum.GetNames(typeof(T))[i];
                ddlitem.Value = value[i].ToString();
                ret.Add(ddlitem);

            }
            return ret;

        }
    }
}
