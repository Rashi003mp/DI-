using EmployeeApi.Models;
using System.Collections.Generic;

namespace EmployeeApi.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Add(Employee employee);
        void Update(int id, Employee employee);
        void Delete(int id);
    }
}
