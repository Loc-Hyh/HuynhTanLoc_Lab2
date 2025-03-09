using TodoApp.Const;

namespace TodoApp.Entities
{
    public class TaskEntity
    {
        // Đại diện cho 1 bảng trong CSDL: SQL Server
        public Guid Id { get; set; } //Guid : gloabal unique indetifier: 128 bit => duy nhất
        public string Title { get; set; } // Tên công việc
        public string Description { get; set; } //Mô tả công việc
        public DateTime CreationDate { get; set; } //Ngày tạo công việc => Auto đặt thời gian hiện tại
        public DateTime DueTime { get; set; } // Thời gian hết hạn công việc => Client nhập vào
        // Kiểu dữ liệu enum: Trạng thái công việc
        public Enums.Status Status { get; set; } // Trạng thái công việc
    }
}
