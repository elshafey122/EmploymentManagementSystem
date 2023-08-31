using AutoMapper;
using EmployeeManagementSystem.Core.Dto;
using EmployeeManagementSystem.Core.IRepositories;
using EmployeeManagementSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taski = EmployeeManagementSystem.Core.Models.Taski;

namespace EmployeeManagementSystem.EF.Repositories
{
    public class TaskRepository : BaseRepository<Taski>,ITaskRepository
    {
        protected readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        public TaskRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Taski> AddTask(TaskDto task)
        {
            var taski = _mapper.Map<Taski>(task);
            await _context.Tasks.AddAsync(taski);
            return taski;
        }

        public async Task<IEnumerable<Employee>> GetManagerEmployees(int managerid)
        {
            var res = _context.Employees.Where(emp => emp.ManagerId == managerid).ToList();
            return res;
        }

        public async Task<IEnumerable<Taski>> GetManagerTasks(int managerid)
        {
            var tasks =_context.Tasks.Where(x => x.AssignFrom == managerid).ToList();
            return tasks;
        }

        public async Task<Taski> UpdateTask(int id ,TaskDto task)
        {
            var oldtask =await _context.Tasks.FindAsync(id);
            oldtask.Description = task.Description;
            oldtask.AssignFrom = task.AssignFrom;
            oldtask.AssignTo = task.AssignTo;
            oldtask.DueDate = task.DueDate;
            return oldtask;
        }
    }
}