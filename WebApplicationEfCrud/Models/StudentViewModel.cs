using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationEfCrud.Models
{
    //Iterates over Model.StudentList and generates a row for each student in the list, displaying their details.
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            StudentList = new List<StudentViewModel>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Age { get; set; }
        public List<StudentViewModel> StudentList { get; set; }
    }
}