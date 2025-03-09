using TodoApp.Data;
using TodoApp.Dtos;
using TodoApp.Dtos.Task;
using TodoApp.Dtos.TaskPaging;
using TodoApp.Entities;

namespace TodoApp.Services.Task
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> GetAll();
        Task<Guid> Create(TaskCreateRequest taskCreateRequest);
        Task<TaskEntity> Update(TaskUpdateRequest taskUpdateRequest);
        Task<bool> Delete(Guid id);
        System.Threading.Tasks.Task Delete(TaskEntity request);
        Task<TaskGetPagingDto> GetPaging(TaskRequest request);
    }
}
