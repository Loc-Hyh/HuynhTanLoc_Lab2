using Microsoft.EntityFrameworkCore;

namespace TodoApp.Data
{
    public class AppDbContext : DbContext //DbContext : phải kế thừa mới sd được
        //Đây là nơi chứa các bảng trong CSDL
        // DbSet : Đại diện cho 1 bảng
    {
        internal object Task;

        // Hàm xây dựng
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }
        // Khai báo bảng
        public DbSet<Entities.TaskEntity> Tasks { get; set; } //Tên bảng: Tasks
        // TaskEntity : đối tượng mình khai báo bằng code c# => tên bảng trong csdl

    }
}
