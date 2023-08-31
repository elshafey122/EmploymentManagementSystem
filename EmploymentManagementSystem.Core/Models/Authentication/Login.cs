using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Models.Authentication
{
    public class Login
    {
        [Required(ErrorMessage = "user name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
    }
}
