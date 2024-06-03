using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Middleware1.Controllers;

[ApiController]
[Route("middleware1")]
public class DemoController : ControllerBase
{
    [HttpGet]
    [Route("sum_ok")]
    public ActionResult<int> GetSumOk([FromBody] int x, [FromHeader] int y) => Ok(x + y);

    [HttpGet]
    [Route("sum_p_sco")]
    public ActionResult<int> GetSumPositiveStatusCodeOverride([FromForm] int x, [FromHeader] int y)
    {
        if (x < 0) return BadRequest("Value x cannot be negative");
        if (y < 0) return BadRequest("Value y cannot be negative");
        return x + y;
    }
}