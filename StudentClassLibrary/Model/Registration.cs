using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary.Model
{
    public class Registration
    {
        public int StudenID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public double GPA { get; set; }
        public bool Active { get; set; }
        public string Status { get; set; }
    }
}
