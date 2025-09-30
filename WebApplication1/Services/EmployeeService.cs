using EmployeeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Position = "Developer", Age = 25 },
            new Employee { Id = 2, Name = "Bob", Position = "Designer", Age = 28 }
        };

        public IEnumerable<Employee> GetAll() => _employees;

        public Employee GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Any() ? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(employee);
            return employee;
        }

        public void Update(int id, Employee updatedEmployee)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return;

            employee.Name = updatedEmployee.Name;
            employee.Position = updatedEmployee.Position;
            employee.Age = updatedEmployee.Age;
        }

        public void Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
                _employees.Remove(employee);
        }
    }
}
