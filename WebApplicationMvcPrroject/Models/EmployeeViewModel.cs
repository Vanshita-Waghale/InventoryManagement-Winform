using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMvcProject.Models  // Corrected the namespace
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            EmployeeList = new List<EmployeeViewModel>();
        }

        public string FirstName { get; set; }
        public string Department { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
    }
}
