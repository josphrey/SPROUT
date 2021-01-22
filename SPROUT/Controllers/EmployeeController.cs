using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Models;

using SPROUT.Core;
using SPROUT.Services;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using SPROUT.Data;

namespace SPROUT.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: EmployeeController
        [HttpGet]
        public ActionResult Index()
        {
            return View(_service.GetAllEmployee());
        }

        // GET: EmployeeController/Salary
        [HttpGet]
        public ActionResult Salary(int id)
        {
            EmployeeViewModel Emp = _service.GetEmployeeById(id);
            if (Emp != null)
            {
                if (Emp.EmployeeType == EmployeeType.Regular.ToString())
                {
                    Emp.ModelLabelSalary = "Monthly Salary";
                    Emp.ModelLabelForWorkingDaysOrAbsences = "Absences";
                }
                else
                {
                    Emp.ModelLabelSalary = "Per Day Rate";
                    Emp.ModelLabelForWorkingDaysOrAbsences = "Reported day/s of work";
                }
            }

            return View(Emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            var emp = new EmployeeViewModel();
            return View(emp);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel emp)
        {
            try
            {
                _service.AddEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/ComputeSalary
        [HttpPost]
        public ActionResult ComputeSalary(EmployeeViewModel emp)
        {
            var Emp = _service.GetSalary(emp);
            return RedirectToAction("SalaryDetails", Emp);
        }

        public ActionResult SalaryDetails(EmployeeViewModel emp)
        {
            return View(emp);
        }
    }
}
