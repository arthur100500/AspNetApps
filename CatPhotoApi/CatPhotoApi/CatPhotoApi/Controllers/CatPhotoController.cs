using CatPhotoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatPhotoApi.Controllers;

[ApiController]
[Route("api")]
public class CatPhotoController : ControllerBase
{
    [HttpPost]
    [Route("post")]
    public IActionResult Post([FromBody] CatPhoto p)
    {
        using var db = new CatPhotoContext();
        db.Add(p);
        db.SaveChanges();

        return Ok();
    }
    
    [HttpGet]
    [Route("get")]
    public ActionResult<List<CatPhoto>> Get()
    {
        using var db = new CatPhotoContext();
        return db.CatPhotos.OrderBy(b => b.CatPhotoId).ToList();
    }
}