using BFF.Api.Data;
using BFF.Api.Todos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bff.Api.Todos;

[ApiController]
public class TodosController(TodosDataContext _context) : ControllerBase
{
    [HttpPost("/completed-todos")]
    public async Task<ActionResult> ToggleTodoCompleted([FromBody] CreateTodoResponse request)
    {
        // see if we have it, if not, return a BadRequest
        var todo = await _context.Todos.SingleOrDefaultAsync(x => x.Id == request.Id);
        if (todo is null)
        {
            return BadRequest("No Todo found to mark complete.");
        }
        // if we do, toggle 'Completed', save it, and then return Ok
        todo.Completed = !todo.Completed;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("/todos")]
    public async Task<ActionResult<GetTodoListResponse>> GetAllTodosAsync(CancellationToken token)
    {
        await Task.Delay(3000, token);
        var list = await _context.Todos
            .OrderBy(t => t.CreatedDate)
            .Select(t => new CreateTodoResponse
            {
                Id = t.Id,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
                Completed = t.Completed,
            }).ToListAsync(token);
        var response = new GetTodoListResponse { List = list };
        return Ok(response);
    }

    [HttpPost("/todos")]
    public async Task<ActionResult<CreateTodoResponse>> AddATodoAsync([FromBody] CreateTodoRequest request)
    {
        await Task.Delay(3000);
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