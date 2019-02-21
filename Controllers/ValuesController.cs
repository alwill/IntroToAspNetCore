using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToAspNetCore_Cooked.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntroToAspNetCore_Cooked.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly Scoped _scoped;
        private readonly Transient _transient;
        private readonly Singelton _singelton;
        private readonly LifeStyleService _lifeStyleService;

        public ValuesController(ICalculatorService calculatorService, Scoped scoped, Transient transient, Singelton singelton, LifeStyleService lifeStyleService)
        {
            _calculatorService = calculatorService;
            _scoped = scoped;
            _transient = transient;
            _singelton = singelton;
            _lifeStyleService = lifeStyleService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<int> Get(int num1, int num2)
        {
            return _calculatorService.Calculate(num1, num2);
        }

        // GET api/values/5

        [HttpGet("{id:int}")]
        public ActionResult<int> Get(int id)
        {
            return id;
        }

        [HttpGet("count")]
        public void GetCount()
        {
            _scoped.IncreaseCount();
            _transient.IncreaseCount();
            _singelton.IncreaseCount();
            _lifeStyleService.Print();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
