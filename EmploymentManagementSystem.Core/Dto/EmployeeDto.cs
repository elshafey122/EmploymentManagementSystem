using EmployeeManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = EmployeeManagementSystem.Core.Models.Taski;

namespace EmployeeManagementSystem.Core.Dto
{
    public class EmployeeDto
    {
        [Required]
        [StringLength(50, ErrorMessage= "you must input name maxlength=50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "you must input age between")]
        [Range(23, 60, ErrorMessage = "you must input age between 23 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "you must enter valid salary")]
        public double Salary { get; set; }

        [EmailAddress(ErrorMessage = "you must enter valid email")]
        [Required(ErrorMessage = "you must enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "you must enter valid phone")]
        public string Phone { get; set; }

        public int? ManagerId { get; set; }

        public int? DeptId { get; set; }

    }
}
