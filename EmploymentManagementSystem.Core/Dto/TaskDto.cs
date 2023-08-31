using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Dto
{
    public class TaskDto
    {
        [StringLength(50, ErrorMessage = "you must input name maxlength=50")]
        [Required(ErrorMessage = "you must enter valid phone")]
        public string Description { get; set; }

        [Required(ErrorMessage = "you must enter valid date")]
        public DateTime DueDate { get; set; }

        public int AssignTo { get; set; }

        public int AssignFrom { get; set; }
    }
}
