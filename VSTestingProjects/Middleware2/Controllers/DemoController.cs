using Microsoft.AspNetCore.Mvc;

namespace Middleware2.Controllers;


[ApiController]
[Route("middleware2")]
public class DemoController : ControllerBase
{
    [HttpGet]
    [Route("sum")]
    public ActionResult<int> GetSum([FromBody] int x, [FromHeader] int y) => x + y;
}