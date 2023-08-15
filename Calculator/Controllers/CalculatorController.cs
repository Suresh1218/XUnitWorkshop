using Calculator.Services;
using Calculator.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorService _calculator;
        public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        [HttpPost("Add")]
        public IActionResult Get(Payload payload)
        {
            return Ok(_calculator.Add(payload.NumberOne, payload.NumberTwo));
        }

        [HttpPost("Subtract")]
        public IActionResult Subtract(Payload payload)
        {
            return Ok(_calculator.Subtract(payload.NumberOne, payload.NumberTwo));
        }

        [HttpPost("Multiple")]
        public IActionResult Multiple(Payload payload)
        {
            return Ok(_calculator.Multiply(payload.NumberOne, payload.NumberTwo));
        }

        [HttpPost("Division")]
        public IActionResult Division(Payload payload)
        {
            return Ok(_calculator.Divide(payload.NumberOne, payload.NumberTwo));
        }
    }
}