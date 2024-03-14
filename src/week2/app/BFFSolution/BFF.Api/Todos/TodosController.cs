using BFF.Api.Data;
using BFF.Api.Todos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bff.Api.Todos;

[ApiController]
public class TodosController(TodosDataContext _context) : ControllerBase
{
    [HttpGet("/todos")]
    public async Task<ActionResult<GetTodoListResponse>> GetAllTodosAsync()
    {
        var list = await _context.Todos
            .OrderBy(t => t.CreatedDate)
            .Select(t => new CreateTodoResponse
            {
                Id = t.Id,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
            }).ToListAsync();
        var response = new GetTodoListResponse { List = list };
        return Ok(response);
    }

    [HttpPost("/todos")]
    public async Task<IActionResult> AddATodoAsync([FromBody] CreateTodoRequest request)
    {
        var todoToAdd = new TodoEntity
        {
            Description = request.Description,
            CreatedDate = DateTime.Now.ToUniversalTime(),
            DueDate = request.DueDate,
            Priority = request.Priority,
        };
        _context.Todos.Add(todoToAdd);
        await _context.SaveChangesAsync();
        var response = new CreateTodoResponse
        {
            Id = todoToAdd.Id,
            Description = todoToAdd.Description,
            DueDate = todoToAdd.DueDate,
            Priority = todoToAdd.Priority,
        };
        return Ok(response);
    }
}