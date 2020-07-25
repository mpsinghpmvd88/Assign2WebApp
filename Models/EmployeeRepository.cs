using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext dbcontext;

        public EmployeeRepository(EmployeeContext context)
        {
            dbcontext = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            dbcontext.Employees.Add(employee);
            dbcontext.SaveChanges();
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return dbcontext.Employees.ToList();
        }
    }
}
