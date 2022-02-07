using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("authenticated")]
    [Authorize]
    public ActionResult<object> GetAuthenticatedTry()
    {
        return Ok($"YLunchApi is running, you are authenticated as {CurrentUserEmail} with Id: {CurrentUserId}");
    }
}
