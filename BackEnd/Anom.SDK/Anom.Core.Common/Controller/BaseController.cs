using System.Net;
using Anom.Core.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anom.Core.Common.Controller;

[Authorize]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult GetIActionResult(Result result)
    {
        if (result == null)
            return StatusCode((int)HttpStatusCode.InternalServerError, null);
    
        return StatusCode(result.Code, result);
    }
}