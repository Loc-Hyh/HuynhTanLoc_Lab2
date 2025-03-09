using System.ComponentModel.DataAnnotations;
using TodoApp.Const;

namespace TodoApp.Dtos.Task
{
    public class TaskCreateRequest
    {
        [Required]
        public string Title { get; set; } // Tên công việc
        [Required]
        public string Description { get; set; } //Mô tả công việc
        [Required]
        public DateTime DueTime { get; set; } // Thời gian hết hạn công việc => Client nhập vào
    }
}
