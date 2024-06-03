using Microsoft.AspNetCore.Mvc;
using VSTestingProjects.Models;

namespace VSTestingProjects.Controllers;

[ApiController]
[Route("simple")]
public class DemoController : ControllerBase
{
    [HttpGet]
    [Route("sum")]
    public ActionResult<int> GetSum([FromBody] int x, [FromHeader] int y) => x + y;

    [HttpGet]
    [Route("sum_positive")]
    public ActionResult<int> GetSumPositive([FromForm] int x, [FromHeader] int y)
    {
        if (x < 0) throw new ArgumentException("Value cannot be negative", nameof(x));
        if (y < 0) throw new ArgumentException("Value cannot be negative", nameof(y));
        return x + y;
    }

    [HttpPost]
    [Route("complex/{fromRoute1:int}/{fromRoute2:int}")]
    public ActionResult<int> Complex(
        [FromQuery(Name="renamedFromQuery1")] int fromQuery1,
        [FromQuery] Wallet fromQuery2,
        [FromHeader] int fromHeader1,
        [FromHeader] int fromHeader2,
        [FromHeader] int fromHeader3,
        [FromForm] Wallet fromForm1,
        [FromForm] int fromForm2,
        [FromRoute] int fromRoute1,
        [FromRoute] int fromRoute2)
    {
        if (fromRoute1 > fromRoute2)
            return Ok(fromRoute1);

        if (fromHeader1 > 5 && fromHeader3 > 5)
            return BadRequest(fromHeader2);

        if (fromHeader1 > 5)
            return Ok(fromForm1.MoneyAmount * fromForm2 + fromQuery1 - fromQuery2.MoneyAmount);

        if (fromHeader2 > 5)
            return NotFound(fromForm1.MoneyAmount - fromForm2 + fromQuery1 * fromQuery2.MoneyAmount);

        if (fromHeader3 > 5)
            return StatusCode(fromHeader3, (fromForm1.MoneyAmount * fromForm2 * fromQuery1 - fromQuery2.MoneyAmount));

        return StatusCode(fromQuery2.MoneyAmount, fromHeader1 * fromHeader2 - fromHeader3);
    }

    [HttpGet]
    [Route("get_wallets")]
    public ActionResult<List<Wallet>> GetWallets()
    {
        using var db = new WalletContext();
        return db.CatPhotos.OrderBy(b => b.MoneyAmount).ToList();
    }
}