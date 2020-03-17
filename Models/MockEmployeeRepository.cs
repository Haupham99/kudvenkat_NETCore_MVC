using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository:IEmployeeRepository
    {
        private List<Employee> listEmployees;

        public MockEmployeeRepository()
        {
            listEmployees = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "A", Email = "1@gmail.com", Department = "Ha Noi"},
                new Employee(){Id = 2,Name = "B", Email = "2@gmail.com", Department = "Ha Noi"},
                new Employee(){Id = 3,Name = "C", Email = "3@gmail.com", Department = "Ha Noi"}
            };
        }
        public Employee GetEmployee(int Id)
        {
            return listEmployees.Find(emp => emp.Id == Id);
        }
    }
}
