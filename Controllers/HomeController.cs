using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _mockEmployeeRepository;

        public HomeController(IEmployeeRepository mockEmployeeRepository)
        {
            _mockEmployeeRepository = mockEmployeeRepository;
        }
        [Route("")]
        public IActionResult Index()
        {
            List<Employee> empList = _mockEmployeeRepository.GetAllEmployees();
            return View(empList);
        }
        [Route("/{id?}")]
        public IActionResult Details(int? id)
        {
            ViewBag.Title = "Pages Detail";
            Employee emp = new Employee();
            emp = _mockEmployeeRepository.GetEmployee(id ?? 1);
            return View(emp);
        }
    }
}