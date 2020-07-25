using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        Employee AddEmployee(Employee employee);
    }
}
