using Microsoft.AspNetCore.Mvc;
using Template.BL.DTOModels;
using Template.BL.Repositories;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericInterface<EmployeeDTO> _employee;
        public EmployeeController(IGenericInterface<EmployeeDTO> employee)
        {
            _employee = employee;

        }
        //[InvalidModelStateHandlerAttribute]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _employee.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _employee.GetAsync(id);
            return Ok(data);
        }
        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeDTO model)
        {
            var data = await _employee.CreateAsync(model);
            return Ok(data);
        }
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeDTO model, int id)
        {
            var data = await _employee.UpdateAsync(model, id);
            return Ok(data);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _employee.DeleteAsync(id);
            return Ok(data);
        }
    }
}
