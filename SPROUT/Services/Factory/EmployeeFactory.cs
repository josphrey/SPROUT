using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Models;

namespace SPROUT.Services
{
    public abstract class EmployeeFactory
    {
        protected abstract IEmployeeSalary EmployeeSalary();

        public IEmployeeSalary Salary()
        {
            return this.EmployeeSalary();
        }
    }
}
