using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Salary { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? ManagerId { get; set; } 

        [ForeignKey(nameof(Departement))]
        public int? DeptId { get; set; }
        [NotMapped]
        public Departement? Departement { get; set; }
        [NotMapped]
        public List<Taski>? Tasks { get; set; }
    }
}
