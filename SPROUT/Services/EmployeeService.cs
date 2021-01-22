using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Models;
using SPROUT.Core;
using SPROUT.Data;
using SPROUT.Entities;
namespace SPROUT.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly EmployeeDbContext _context;
        IEmployeeSalary employeeSalary;

        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }

        public EmployeeViewModel GetSalary(EmployeeViewModel employeeviewmodel)
        {
            EmployeeViewModel emp = new EmployeeViewModel();

            switch (employeeviewmodel.EmployeeType)
            {
                case "Regular":
                    employeeSalary = new ConcreteCreator.RegularEmployeeFactory().Salary();
                    emp.ModelLabelSalary = "Monthly Salary";
                    emp.ModelLabelForWorkingDaysOrAbsences = "Absences";
                    break;
                case "Contractual":
                    employeeSalary = new ConcreteCreator.ContractualEmployeeFactory().Salary();
                    emp.ModelLabelSalary = "Per Day Rate";
                    emp.ModelLabelForWorkingDaysOrAbsences = "No. Day/s of work";
                    break;

                default:
                    throw new NotImplementedException();
            }

            employeeSalary.SalaryRate = employeeviewmodel.Salary;
            employeeSalary.NumberWorkingDayOrAbsences = employeeviewmodel.NumberWorkingDaysOrAbsences;
            emp.Id = employeeviewmodel.Id;
            emp.Name = employeeviewmodel.Name;
            emp.Birthday = employeeviewmodel.Birthday;
            emp.Tin = employeeviewmodel.Tin;
            emp.EmployeeType = employeeviewmodel.EmployeeType;
            emp.Salary = employeeviewmodel.Salary;
            emp.NumberWorkingDaysOrAbsences = employeeviewmodel.NumberWorkingDaysOrAbsences;
            emp.DailyRate = employeeSalary.DailyRate();
            emp.WTax = employeeSalary.WTax();
            emp.TotalDeduction = employeeSalary.Deduction();
            emp.TotalSalary = employeeSalary.TotalSalary();

            return emp;
        }

        public List<EmployeeViewModel> GetAllEmployee()
        {
            List<Employee> lstEmp = _context.Employee.ToList();
            List<EmployeeViewModel> retLstEmp = new List<EmployeeViewModel>();

            if (lstEmp != null)
            {
                foreach (Employee item in lstEmp)
                {
                    EmployeeViewModel model = new EmployeeViewModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Birthday = item.Birthday;
                    model.Tin = item.Tin;
                    model.EmployeeType = item.EmployeeType;

                    retLstEmp.Add(model);
                }
            }

            return retLstEmp;
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            Employee emp = _context.Employee.Find(id);
            EmployeeViewModel viewmodel = new EmployeeViewModel();

            if (emp != null)
            {
                viewmodel.Id = emp.Id;
                viewmodel.Name = emp.Name;
                viewmodel.Birthday = emp.Birthday;
                viewmodel.Tin = emp.Tin;
                viewmodel.EmployeeType = emp.EmployeeType;
            }

            return viewmodel;
        }

        public void AddEmployee(EmployeeViewModel employee)
        {
            var emp = new Employee() 
            { 
                Name = employee.Name,
                Birthday = employee.Birthday,
                Tin = employee.Tin,
                EmployeeType = employee.EmployeeType
            };

            _context.Employee.Add(emp);
            _context.SaveChanges();
        }
    }

    public interface IEmployeeService
    {
        EmployeeViewModel GetSalary(EmployeeViewModel employeeviewmodel);
        List<EmployeeViewModel> GetAllEmployee();
        EmployeeViewModel GetEmployeeById(int id);
        void AddEmployee(EmployeeViewModel employee);
    }
}
