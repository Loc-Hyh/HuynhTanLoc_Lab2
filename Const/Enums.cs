using System.ComponentModel;

namespace TodoApp.Const
{
    public static class Enums // static : có thể được truy cập trực tiếp từ mọi nơi trong project
        // Kiểu dữ liệu chỉ dược sử dụng để đọc, không gán giá trị được
        // Kiểu giá trị là 1 hằng số
    {
        // Định nghĩa 1 kiểu dữ liệu là trạng thái của công việc
        // OOP: lập trình hướng đối tượng: đóng gói dữ liệu : private: chỉ sử dụng trong 1 class, public: công khai với nhiều class
        public enum Status
        {
            [Description("Chưa làm")]
            Pending, // Không khai báo bằng 0, thì nó mặc định là 0
            [Description("Đang làm")]
            Working,
            [Description("Hoàn thành")]
            Conpleted,
        }
    }
}
