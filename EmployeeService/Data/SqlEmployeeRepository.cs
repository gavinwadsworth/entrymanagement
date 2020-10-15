using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeService.Models;

namespace EmployeeService.Data
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public SqlEmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Remove(employee);
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee employee)
        {
            // Not required.
        }
    }
}
