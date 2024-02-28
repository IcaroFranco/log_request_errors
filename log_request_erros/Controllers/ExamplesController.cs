using log_request_erros.models;
using Microsoft.AspNetCore.Mvc;

namespace log_request_erros.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(
        [FromBody] ExampleRequest request)
    {
        return Ok(request);
    }
}
