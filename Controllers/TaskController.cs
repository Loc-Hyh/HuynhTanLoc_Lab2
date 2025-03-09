using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Dtos;
using TodoApp.Dtos.Task;
using TodoApp.Dtos.TaskPaging;
using TodoApp.Entities;
using TodoApp.Services.Task;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _taskService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]TaskCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _taskService.Create(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("delete/id")]
        public async Task<IActionResult> DeleteID(Guid id)
        {
            var result = await _taskService.Delete(id);
            return Ok("Đã xóa công việc có id là: "+id+" thành công");
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(TaskUpdateRequest request)
        {
            var result = await _taskService.Update(request);
            return Ok("Câp nhật thành công");
        }
        [HttpPost("GetPaging")]
        public async Task<IActionResult> GetPaging([FromBody]TaskRequest request)
        {
            var result = await _taskService.GetPaging(request);
            return Ok(result);
        }
    
    }
}
