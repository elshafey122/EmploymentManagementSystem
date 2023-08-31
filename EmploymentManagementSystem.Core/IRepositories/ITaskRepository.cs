using EmployeeManagementSystem.Core.Dto;
using EmployeeManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepositories
{
    public interface ITaskRepository:IBaseRepository<Taski>
    {
        Task<Taski> AddTask(TaskDto task);
        Task<Taski>UpdateTask(int id,TaskDto task);
        Task<IEnumerable<Employee>> GetManagerEmployees(int Managerid);
        Task<IEnumerable<Taski>> GetManagerTasks(int Managerid);
    }
}
