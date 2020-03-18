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
                new Employee(){Id = 1, Name = "A", Email = "1@gmail.com", Department = Dept.IT},
                new Employee(){Id = 2,Name = "B", Email = "2@gmail.com", Department = Dept.HR},
                new Employee(){Id = 3,Name = "C", Email = "3@gmail.com", Department = Dept.PM}
            };
        }
        public Employee GetEmployee(int Id)
        {
            return listEmployees.Find(emp => emp.Id == Id);
        }
        public List<Employee> GetAllEmployees()
        {
            return listEmployees;
        }

        public Employee AddEmployee(Employee emp)
        {
            //emp.Id = listEmployees.Max(e => e.Id) + 1;
            this.listEmployees.Add(emp);
            return emp;
        }
    }
}
