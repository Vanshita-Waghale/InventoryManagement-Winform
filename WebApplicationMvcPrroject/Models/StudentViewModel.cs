using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMvcPrroject.Models
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            FruitsList = new List<string>();
            
        }
        public string Name {  get; set; }
        public string City { get; set; }

        
        public List<string> FruitsList { get; set; }
       
    }
}