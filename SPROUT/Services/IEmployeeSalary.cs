using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPROUT.Services
{
    public interface IEmployeeSalary
    {
        decimal SalaryRate { get; set; }
        decimal NumberWorkingDayOrAbsences { get; set; }
        decimal WTax();
        decimal DailyRate();
        decimal Deduction();
        decimal TotalSalary();
    }
}
