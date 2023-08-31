using EmployeeManagementSystem.Core;
using EmployeeManagementSystem.Core.Dto;
using EmployeeManagementSystem.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllEmps")]
        public async Task<IActionResult> GetAllEmps()
        {
            return Ok(await _unitOfWork.Employees.GetAllData());
        }

        [HttpGet("GetEmp/{id}")]
        public async Task<IActionResult> GetDept(int id)
        {
            Employee emp = await _unitOfWork.Employees.GetById(id);
            if (emp == null)
            {
                return NotFound(emp);
            }
            return Ok(emp);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmp(EmployeeDto emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = await _unitOfWork.Employees.AddEmployee(emp);
            _unitOfWork.Complete();
            return Created($"/api/GetEmp/{employee.Id}", employee);
        }

        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmp(int id , EmployeeDto emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = await _unitOfWork.Employees.UpdateEmployee(id,emp);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("DeleteEmp/{id}")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            var emp = _unitOfWork.Employees.Delete(id);
            if (emp == 0)
            {
                return NotFound();
            }
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
