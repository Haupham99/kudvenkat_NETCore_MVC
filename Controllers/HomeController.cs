using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _mockEmployeeRepository;

        public HomeController(IEmployeeRepository mockEmployeeRepository)
        {
            _mockEmployeeRepository = mockEmployeeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            ViewData["Title1"] = "Hậu Phạm";
            ViewBag.Title = "Pages Detail";
            List<Employee> empList = new List<Employee>();
            empList.Add(_mockEmployeeRepository.GetEmployee(1));
            empList.Add(_mockEmployeeRepository.GetEmployee(2));
            return View(empList);
        }
    }
}