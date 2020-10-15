using System.Collections.Generic;
using EmployeeService.Models;

namespace EmployeeService.Data
{
    public interface IEmployeeRepository
    {
        bool SaveChanges();
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
