using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // In-memory storage
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Position = "Developer", Age = 25 },
            new Employee { Id = 2, Name = "Bob", Position = "Designer", Age = 28 }
        };

        // GET: api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return Ok(employees);
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee> Add(Employee employee)
        {
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            employee.Name = updatedEmployee.Name;
            employee.Position = updatedEmployee.Position;
            employee.Age = updatedEmployee.Age;

            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            employees.Remove(employee);
            return NoContent();
        }
    }
}
