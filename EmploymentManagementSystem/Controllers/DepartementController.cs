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
    [Authorize(Roles ="admin")]

    public class DepartementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllDepts")]
        public async Task<IActionResult> GetAllDepts()
        {
            return Ok(await _unitOfWork.Departements.GetAllData());
        }

        [HttpGet("GetDept/{id}")]
        public async Task<IActionResult> GetDept(int id)
        {
            Departement dept = await _unitOfWork.Departements.GetById(id);
            if (dept == null)
            {
                return NotFound(dept);
            }
            return Ok(dept);
        }

        [HttpPost("AddDept")]
        public async Task<IActionResult> AddDept([FromBody] DeptDto dept)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(dept.Name, "something went wrong");
                return BadRequest(ModelState);
            }
            Departement newdept = await _unitOfWork.Departements.AddDept(dept);
            _unitOfWork.Complete();
            return Created($"/api/GetAllDept/{newdept.Id}", newdept);
        }

        [HttpPut("UpdateDept/{id}")]
        public async Task<IActionResult> UpdateDept([FromRoute]int id, [FromBody] DeptDto dept)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(dept.Name, "something went wrong");
                return BadRequest(ModelState);
            }
            await _unitOfWork.Departements.UpdateDept(id, dept);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("DeleteDept/{id}")]
        public async Task<IActionResult> DeleteDept([FromRoute]int id)
        {
            var dept = _unitOfWork.Departements.Delete(id);
            if (dept == 0)
            {
                return NotFound();
            }
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
