using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult HandleError(string errorMessage, int statusCode = StatusCodes.Status400BadRequest)
        {
            var errorResponse = new
            {
                Error = errorMessage,
                StatusCode = statusCode
            };

            return StatusCode(statusCode, errorResponse);
        }
    }
}