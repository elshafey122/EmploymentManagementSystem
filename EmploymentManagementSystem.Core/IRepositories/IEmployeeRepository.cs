using EmployeeManagementSystem.Core.Dto;
using EmployeeManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepositories
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<Employee> AddEmployee(EmployeeDto emp);
        Task<Employee> UpdateEmployee(int id,EmployeeDto emp);
    }
}
