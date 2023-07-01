using Microsoft.AspNetCore.Mvc;

namespace Gathering.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}