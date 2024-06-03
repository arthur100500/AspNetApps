using CatPhotoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatPhotoApi.Controllers;

[ApiController]
[Route("api")]
public class CatPhotoController : ControllerBase
{
    [HttpPost]
    [Route("post2/{fromRoute1:int}/{fromRoute2:int}")]
    public ActionResult<int> Post2(
        [FromQuery(Name="renamedFromQuery1")] int fromQuery1,
        [FromQuery] CatPhoto fromQuery2,
        [FromHeader] int fromHeader1,
        [FromHeader] int fromHeader2,
        [FromHeader] int fromHeader3,
        [FromForm] int fromForm1,
        [FromForm] int fromForm2,
        [FromRoute] int fromRoute1,
        [FromRoute] int fromRoute2)
    {
        if (fromRoute1 > fromRoute2)
            return fromRoute1;

        if (fromHeader1 > 5 && fromHeader3 > 5)
            return fromHeader2;

        if (fromHeader1 > 5)
            return (fromForm1 * fromForm2 + fromQuery1 - fromQuery2.CatPhotoId);

        if (fromHeader2 > 5)
            return (fromForm1 - fromForm2 + fromQuery1 * fromQuery2.CatPhotoId);

        if (fromHeader3 > 5)
            return (fromForm1 * fromForm2 * fromQuery1 - fromQuery2.CatPhotoId);

        return fromHeader1 * fromHeader2 - fromHeader3;
    }


    [HttpPost]
    [Route("post")]
    public ActionResult<CatPhoto> Post([FromQuery] CatPhoto t)
    {
        if (t.CatPhotoId < 10) throw new ArgumentException("Id < 10");

        t.Url = "Cool" + t.Url;
        t.CatName = "Cool" + t.CatName;

        return t;
    }
    
    [HttpGet]
    [Route("get")]
    public ActionResult<List<CatPhoto>> Get()
    {
        var photo = new CatPhoto("sample.url.com", "Sample Cat");
        return new List<CatPhoto>{photo};
    }

    [HttpGet]
    [Route("get2")]
    public int Get2()
    {
        return 4;
    }
}