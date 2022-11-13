using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTaskController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeTaskService _employeeTaskService;

        public EmployeeTaskController(UserManager<AppUser> userManager, IEmployeeTaskService employeeTaskService)
        {
            _userManager = userManager;
            _employeeTaskService = employeeTaskService;
        }

        public async Task<IActionResult> EmployeeTaskListByProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var taskList = _employeeTaskService.TGetEmployeeTaskById(values.Id);

            return View(taskList);
        }
    }
}
