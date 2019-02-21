using Microsoft.AspNetCore.Mvc;

namespace IntroToAspNetCore_Cooked.Controllers
{
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult("Sorry an Error occurred")
            {
                StatusCode = 500
            };
        }
    }
}