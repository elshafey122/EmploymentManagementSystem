using EmployeeManagementSystem.Core.IRepositories;
using EmployeeManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDeptRepository Departements {get;}
        IEmployeeRepository Employees { get; }
        ITaskRepository Tasks { get; }
        int Complete();
    }
}
