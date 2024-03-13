using BFF.Api.Todos;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Api.Todos;

public class TodosController : ControllerBase
{
    [HttpPost("/todos")]
    public IActionResult AddATodo([FromBody] CreateTodoRequest request)
    {
        var response = new CreateTodoResponse
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority
        };
        return Ok(response);
    }
}