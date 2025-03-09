namespace TodoApp.Dtos.TaskPaging
{
    public class TaskRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? SearchText { get; set; }
    }
}
