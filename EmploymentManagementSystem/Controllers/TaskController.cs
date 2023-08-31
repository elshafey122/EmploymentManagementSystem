using EmployeeManagementSystem.Core;
using EmployeeManagementSystem.Core.Dto;
using EmployeeManagementSystem.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taski = EmployeeManagementSystem.Core.Models.Taski;

namespace EmployeeManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("GetManagerTasks/{managerid}")]
        public async Task<IActionResult> GetAllEmployeeTasks(int managerid)
        {
            Employee manager = await _unitOfWork.Employees.GetById(managerid);
            if (manager == null)
            {
                return Unauthorized("Manager is not autherized");
            }
            return Ok(await _unitOfWork.Tasks.GetManagerTasks(managerid));
        }

        [HttpGet("GetmanagerEmployees/{managerId}")]
        public async Task<IActionResult> GetmanagerEmployees(int managerId)
        {
            Employee manager = await _unitOfWork.Employees.GetById(managerId);
            if (manager == null)
            {
                return Unauthorized("Manager is not authorized");
            }
            var res =await _unitOfWork.Tasks.GetManagerEmployees(managerId);
            return Ok(res);
        }

        [HttpGet("GetTask/{id}")]
        public async Task<IActionResult> GetTask(int id, int managerid)
        {
            Employee manager = await _unitOfWork.Employees.GetById(managerid);
            if (manager == null)
            {
                return Unauthorized("Manager is not autherized");
            }
            Taski task = await _unitOfWork.Tasks.GetById(id);
            if (task == null)
            {
                return NotFound(task);
            }
            return Ok(task);
        }

        [HttpPost("AddTask/{managerid}")]
        public async Task<IActionResult> AddTask(int managerid, TaskDto taski)
        {
            Employee manager = await _unitOfWork.Employees.GetById(managerid);
            Employee employee = await _unitOfWork.Employees.GetById(taski.AssignTo);
            if (manager == null)
            {
                return Unauthorized("Manager is not autherized");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = await _unitOfWork.Tasks.AddTask(taski);
            _unitOfWork.Complete();
            return Created($"/api/GetTask/{task.TaskiId}", task);
        }

        [HttpPut("EditTask/{id}")]
        public async Task<IActionResult> EditTask(int id , int managerid, TaskDto taski)
        {
            Employee manager = await _unitOfWork.Employees.GetById(managerid);
            if (manager == null)
            {
                return Unauthorized("Manager is not autherized");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = await _unitOfWork.Tasks.UpdateTask(id, taski);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTak(int id, int managerid)
        {
            Employee manager = await _unitOfWork.Employees.GetById(managerid);
            if (manager == null)
            {
                return Unauthorized("Manager is not autherized");
            }
            var task = _unitOfWork.Tasks.Delete(id);
            if (task == 0)
            {
                return NotFound();
            }
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
