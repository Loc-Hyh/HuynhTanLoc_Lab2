using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TodoApp.Const;
using TodoApp.Data;
using TodoApp.Dtos;
using TodoApp.Dtos.Task;
using TodoApp.Dtos.TaskPaging;
using TodoApp.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TodoApp.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public  async Task<Guid> Create(TaskCreateRequest request)
        {
            var taskExits = await _context.Tasks.FirstOrDefaultAsync(p => p.Title == request.Title);
            if (taskExits!=null)
            {
                throw new Exception("Công việc đã tồn tại");
            }
            var entity = new TaskEntity
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                CreationDate = DateTime.Now,
                DueTime = request.DueTime,
                Status = Enums.Status.Pending
            };
            var result = await _context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;

        }

        public async Task<Guid> Delete(TaskEntity taskEntity)
        {
            var entity= await _context.Tasks.FirstOrDefaultAsync(p=>p.Id == taskEntity.Id);
            if (entity == null)
            {
                throw new Exception("Không tông tại công việc");
            }
            if(!string.IsNullOrEmpty(entity.Title))
            {
                taskEntity.Title = entity.Title;
            }
            if(!string.IsNullOrEmpty (entity.Description))
            {
                taskEntity.Description = entity.Description;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteID(Guid id)
        {
            var entity = _context.Tasks.FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                return false;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskEntity>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskGetPagingDto> GetPaging(TaskRequest request)
        {
            var taskExits =_context.Tasks.Where(p => p.Title.Contains(request.SearchText));
            if (!await taskExits.AnyAsync())
            {
                throw new Exception("Không tìm thấy công việc");
            }
            var result = await taskExits.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            var dataReponse = new TaskGetPagingDto
            {
                Items = result,
                TotalRecord = await _context.Tasks.CountAsync()
            };
            return dataReponse;
        }

        public async Task<TaskEntity> Update(TaskUpdateRequest taskUpdateRequest)
        {
            var entity=await _context.Tasks.FirstOrDefaultAsync(p=>p.Id == taskUpdateRequest.Id);
            if (entity==null)
            {
                throw new Exception("Không tồn tại công việc");
            }
            entity.Title = taskUpdateRequest.Title;
            entity.Description = taskUpdateRequest.Description;
            entity.Status = taskUpdateRequest.Status;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        System.Threading.Tasks.Task ITaskService.Delete(TaskEntity request)
        {
            return Delete(request);
        }
    }
}
