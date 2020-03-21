using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return emp; 
        }

        public Employee DeleteEmployee(int Id)
        {
            Employee emp = _context.Employees.Find(Id);
            if(emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public Employee UpdateEmployee(Employee emp)
        {
            Employee employee = _context.Employees.Find(emp.Id);
            if(employee != null)
            {
                employee.Name = emp.Name;
                employee.Email = emp.Email;
                employee.Department = emp.Department;
                _context.SaveChanges();
            }
            return employee;
        }
    }
}
