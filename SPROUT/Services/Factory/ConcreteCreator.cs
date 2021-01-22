using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Models;

namespace SPROUT.Services
{
    public class ConcreteCreator
    {
        public class RegularEmployeeFactory : EmployeeFactory
        {
            protected override IEmployeeSalary EmployeeSalary()
            {
                IEmployeeSalary salary = new Regular();
                return salary;
            }
        }

        public class ContractualEmployeeFactory : EmployeeFactory
        {
            protected override IEmployeeSalary EmployeeSalary()
            {
                IEmployeeSalary salary = new Contractual();
                return salary;
            }
        }

        public class ProbationaryEmployeeFactory : EmployeeFactory
        {
            protected override IEmployeeSalary EmployeeSalary()
            {
                IEmployeeSalary salary = new Probationary();
                return salary;
            }
        }
    }
}
