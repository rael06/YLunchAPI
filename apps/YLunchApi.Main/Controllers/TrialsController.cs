using Microsoft.AspNetCore.Mvc;

namespace YLunchApi.Main.Controllers;

[ApiController]
[Route("[controller]")]
public class TrialsController : ApplicationControllerBase
{
    [HttpGet("anonymous")]
    public ActionResult<object> GetAnonymousTry()
    {
        return Ok("YLunchApi is running, you are anonymous");
    }
}
