using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository repository;

        public EmployeesController(IEmployeeRepository repository)
        {           
            this.repository = repository;
        }
        public IActionResult Index()
        {
            List<Employee> list = repository.GetEmployees();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
         public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                repository.AddEmployee(employee);
                return RedirectToAction("index", "employees");
            }
            return View();
            
        }
    }
}
