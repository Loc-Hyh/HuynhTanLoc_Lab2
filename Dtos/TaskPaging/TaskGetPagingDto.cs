using TodoApp.Entities;

namespace TodoApp.Dtos.TaskPaging
{
    public class TaskGetPagingDto
    {
        public List<TaskEntity> Items { get; set; } 
        public int TotalRecord { get; set; }

    }
}
