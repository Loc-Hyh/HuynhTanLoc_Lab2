using System.ComponentModel.DataAnnotations;
using TodoApp.Const;

namespace TodoApp.Dtos
{
    public class TaskUpdateRequest
    {
        [Required]
        public Guid Id { get; set; } //Guid : gloabal unique indetifier: 128 bit => duy nhất
        public string Title { get; set; } // Tên công việc
        public string Description { get; set; } //Mô tả công việc
        public Enums.Status Status { get; set; } // Trạng thái công việc
    }
}
