using System;
using System.Collections.Generic;
using EmployeeService.Models;

namespace EmployeeService.Data
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public void CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            return new Employee { Id = 0, Title = "Mr", FirstName = "Test", LastName = "Teacher", EmailAddress = "mrtestteacher@testschool.com", PhoneNumber = "0123456789", FormTutor = true, AccessibilityRequirements = "", DBSExpiry = DateTime.Now.AddYears(2) };
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>
            {
            new Employee { Id = 0, Title = "Mr", FirstName = "Test", LastName = "Teacher", EmailAddress = "mrtestteacher@testschool.com", PhoneNumber = "0123456789", FormTutor = true, AccessibilityRequirements = "", DBSExpiry = DateTime.Now.AddYears(2) },
            new Employee { Id = 1, Title = "Miss", FirstName = "Test", LastName = "Teacher", EmailAddress = "misstestteacher@testschool.com", PhoneNumber = "0987654321", FormTutor = true, AccessibilityRequirements = "", DBSExpiry = DateTime.Now.AddYears(2) },
            new Employee { Id = 2, Title = "Mr", FirstName = "Support", LastName = "Staff", EmailAddress = "mrsupportstaff@testschool.com", PhoneNumber = "0123498765", FormTutor = false, AccessibilityRequirements = "", DBSExpiry = DateTime.Now.AddYears(2) }
            };
            return employees;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
