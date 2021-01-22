using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPROUT.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Tin { get; set; }
        public string EmployeeType { get; set; }
    }
}
