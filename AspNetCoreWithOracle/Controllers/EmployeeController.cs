using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithOracle.Interface;
using AspNetCoreWithOracle.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithOracle.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public ActionResult Index()
        {
            IEnumerable<Employees> employee = employeeService.GetAllEmployee();
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            employeeService.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            Employees employee = employeeService.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employees employee)
        {
            employeeService.EditEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            Employees employee = employeeService.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(Employees employee)
        {
            employeeService.DeleteEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
