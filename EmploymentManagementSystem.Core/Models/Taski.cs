using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Models
{
    public class Taski
    {
        public int TaskiId { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        [ForeignKey(nameof(Employee))]
        public int AssignTo { get; set; }

        public int AssignFrom { get; set; }
        [NotMapped]
        public Employee? Employee { get; set; }

    }
}
