using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SPROUT.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Id = 0;
            Name = "";
            Birthday = DateTime.Now.AddYears(-20);
            Tin = 0;
            EmployeeType = "";
            Salary = 0;
            DailyRate = 0;
            NumberWorkingDaysOrAbsences = 0;
            TotalDeduction = 0;
            TotalSalary = 0;
            ModelLabelSalary = "";
            ModelLabelForWorkingDaysOrAbsences = "";
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-DD}")]
        public DateTime Birthday { get; set; }

        [Required]
        public int Tin { get; set; }
        [Required]
        public string EmployeeType { get; set; }

        public string ModelLabelSalary { get; set; }

        [Required]
        [Range(1, 1000000000000000000, ErrorMessage = "Salary must be greter than zero !")]
        public decimal Salary { get; set; }
        public decimal DailyRate { get; set; }
        public string ModelLabelForWorkingDaysOrAbsences { get; set; }

        [Required]
        public decimal NumberWorkingDaysOrAbsences { get; set; }
        //public int Tax { get; set; }
        public decimal WTax { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal TotalSalary { get; set; }
    }
}

