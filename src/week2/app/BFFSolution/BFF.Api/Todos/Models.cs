using System.ComponentModel.DataAnnotations;

namespace BFF.Api.Todos;

public record CreateTodoRequest
{
    [Required, MinLength(3), MaxLength(124)]
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; } // nullable
}

public enum TodoPriority { Low, High };

public record CreateTodoResponse
{
    [Required]
    public Guid Id { get; set; }
    [Required, MinLength(3), MaxLength(124)]
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; } // nullable
    public bool Completed { get; set; }
}

public record GetTodoListResponse
{
    public IList<CreateTodoResponse>? List { get; set; }
}