namespace BFF.Api.Todos;

public record CreateTodoRequest
{
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; } // nullable
}

public enum TodoPriority { Low, High };

public record CreateTodoResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; } // nullable
}