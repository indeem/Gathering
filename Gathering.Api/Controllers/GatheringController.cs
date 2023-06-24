using Microsoft.AspNetCore.Mvc;

namespace Gathering.Api.Controllers;

public class GatheringController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}