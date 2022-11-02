using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.BusinessLayer.Concrete;
using Crm.UpSchool.BusinessLayer.ValidationRules;
using Crm.UpSchool.DataAccessLayer.EntityFramework;
using Crm.UpSchool.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.TGetEmployeesByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            EmployeeValidator validationRules = new EmployeeValidator();
            ValidationResult result = validationRules.Validate(employee);
            if (result.IsValid)
            {
                _employeeService.TInsert(employee);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteEmployee(int id)
        {
            var values = _employeeService.TGetByID(id);
            _employeeService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
//ninject
//rulefor neden başlangıçta ctor metot olmadan gelmiyor
//örnek bir yazılım analiz dokümanı