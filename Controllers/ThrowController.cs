using System;
using Microsoft.AspNetCore.Mvc;

namespace IntroToAspNetCore_Cooked.Controllers
{
    [Route("[controller]")]
    public class ThrowController : ControllerBase
    {
        [HttpGet]
        public void Get()
        {
            throw new Exception("FOO Bar");
        }
    }
}