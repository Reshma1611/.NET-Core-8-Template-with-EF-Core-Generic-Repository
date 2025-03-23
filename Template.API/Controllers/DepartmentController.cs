using Microsoft.AspNetCore.Mvc;
using Template.BL.DTOModels;
using Template.BL.Repositories;
using Template.BL.Services;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IGenericInterface<DepartmentDTO> _department;
        public DepartmentController(IGenericInterface<DepartmentDTO> department)
        {
            _department = department;
            
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _department.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _department.GetAsync(id);
            return Ok(data);
        }
        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody]DepartmentDTO model)
        {
            var data = await _department.CreateAsync(model);
            return Ok(data);
        }
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] DepartmentDTO model, int id)
        {
            var data = await _department.UpdateAsync(model, id);
            return Ok(data);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _department.DeleteAsync(id);
            return Ok(data);
        }
    }
}
