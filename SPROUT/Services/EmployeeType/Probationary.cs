using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Models;

namespace SPROUT.Services
{
    public class Probationary : IEmployeeSalary
    {
        public decimal SalaryRate { get; set; }
        public decimal NumberWorkingDayOrAbsences { get; set; }

        public decimal DailyRate()
        {
            throw new NotImplementedException();
        }

        public decimal Deduction()
        {
            throw new NotImplementedException();
        }

        public decimal TotalSalary()
        {
            throw new NotImplementedException();
        }

        public decimal WTax()
        {
            throw new NotImplementedException();
        }
    }
}
