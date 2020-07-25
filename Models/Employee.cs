using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Please enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter designation")]
        public string Designation { get; set; }
    }
}
