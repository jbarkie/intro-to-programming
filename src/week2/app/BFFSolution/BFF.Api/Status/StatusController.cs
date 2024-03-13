using Microsoft.AspNetCore.Mvc;

namespace BFF.Api.Status;

public class StatusController : ControllerBase
{
    // GET /status
    [HttpGet("/status")]
    public IActionResult GetTheStatus()
    {
        return Ok("Everything is groovy");
    }
}
