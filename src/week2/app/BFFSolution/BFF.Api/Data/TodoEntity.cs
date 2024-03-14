using BFF.Api.Todos;

namespace BFF.Api.Data;

public class TodoEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; } // nullable
    public DateTimeOffset? CreatedDate { get; set; }
    public bool Completed { get; set; } = false;
}