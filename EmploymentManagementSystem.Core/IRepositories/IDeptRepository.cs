using EmployeeManagementSystem.Core.Dto;
using EmployeeManagementSystem.Core.Models;

namespace EmployeeManagementSystem.Core.IRepositories
{
    public interface IDeptRepository :IBaseRepository<Departement>
    {
        Task<Departement> AddDept(DeptDto dept);
        Task<Departement> UpdateDept(int id,DeptDto dept);
    }
}
