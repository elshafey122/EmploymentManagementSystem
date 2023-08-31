using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Dto
{
    public class DeptDto
    {
        [MaxLength(50,ErrorMessage ="title no more than 50 characters")]
        [Required]
        public string Name { get; set; }
    }
}
