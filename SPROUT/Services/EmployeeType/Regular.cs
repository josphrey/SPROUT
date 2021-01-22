using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Models;

namespace SPROUT.Services
{
    public class Regular : IEmployeeSalary
    {
        public decimal SalaryRate { get; set; }
        public decimal NumberWorkingDayOrAbsences { get; set; }

        public decimal DailyRate()
        {
            return Decimal.Round((SalaryRate / 22), 2);
        }
        public decimal WTax()
        {
            return Decimal.Round(SalaryRate * Convert.ToDecimal(0.12), 2);
        }
        public decimal Deduction()
        {
            return Decimal.Round(((DailyRate() * NumberWorkingDayOrAbsences) + WTax()), 2);
        }
        public decimal TotalSalary()
        {
            return Decimal.Round((SalaryRate - Deduction()), 2);
        }
    }
}
