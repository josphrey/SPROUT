using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Models;

namespace SPROUT.Services
{
    public class Contractual : IEmployeeSalary
    {
        public decimal SalaryRate { get; set; }
        public decimal NumberWorkingDayOrAbsences { get; set; }

        public decimal DailyRate()
        {
            return SalaryRate;
        }

        public decimal Deduction()
        {
            return (0);
        }

        public decimal TotalSalary()
        {
            return Decimal.Round((SalaryRate * NumberWorkingDayOrAbsences), 2);
        }

        public decimal WTax()
        {
            return 0;
        }
    }
}
