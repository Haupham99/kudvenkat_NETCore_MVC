using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _mockEmployeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IEmployeeRepository mockEmployeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _mockEmployeeRepository = mockEmployeeRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Route("")]
        public IActionResult Index()
        {
            IEnumerable<Employee> empList = _mockEmployeeRepository.GetAllEmployees();
            return View(empList);
        }
       
        public IActionResult Details(int? id)
        {
            ViewBag.Title = "Pages Detail";
            Employee emp = new Employee();
            emp = _mockEmployeeRepository.GetEmployee(id ?? 1);
            HomeDetailsViewModel model = new HomeDetailsViewModel() { Employee = emp };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid) {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string pathFile = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(pathFile, FileMode.Create));
                }
                Employee newEmp = new Employee {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _mockEmployeeRepository.AddEmployee(newEmp);
                return RedirectToAction("Details", new { id = newEmp.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete(int Id)
        {
            _mockEmployeeRepository.DeleteEmployee(Id);
            return RedirectToAction("Index");
        }
    }
}