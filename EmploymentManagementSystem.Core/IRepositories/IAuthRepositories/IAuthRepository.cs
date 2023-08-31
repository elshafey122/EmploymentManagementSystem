using EmployeeManagementSystem.Core.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepositories.IAuthRepositories
{
    public interface IAuthRepository
    {
         Task <int> Register(Register regster);
    }
}
