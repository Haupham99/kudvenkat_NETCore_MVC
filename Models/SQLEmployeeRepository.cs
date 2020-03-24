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
            var employee = _context.Employees.Attach(emp);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return emp;
        }
    }
}
