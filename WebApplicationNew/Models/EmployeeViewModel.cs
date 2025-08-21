using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationNew.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            EmployeeList = new List<EmployeeViewModel>();
        }
        public int id { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
    }
}