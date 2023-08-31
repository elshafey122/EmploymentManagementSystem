using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Models
{
    public class Departement
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public List<Employee>? Employees { get; set; }
    }
}
