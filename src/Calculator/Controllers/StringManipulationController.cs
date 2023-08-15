using Calculator.Controllers;
using Calculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringManipulationController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IStringManipulatorService _stringManipulatorService;
        public StringManipulationController(ILogger<CalculatorController> logger, IStringManipulatorService stringManipulatorService)
        {
            _logger = logger;
            _stringManipulatorService = stringManipulatorService;
        }

        [HttpGet]
        [Route("api/string/reverse")]
        public IActionResult ReverseString(string input)
        {
            try
            {
                string reversedString = _stringManipulatorService.ReverseString(input);
                return Ok(reversedString);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/string/palindrome")]
        public IActionResult IsPalindrome(string input)
        {
            try
            {
                bool isPalindrome = _stringManipulatorService.IsPalindrome(input);
                return Ok(isPalindrome);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/string/occurrences")]
        public IActionResult CountOccurrences(string input, char character)
        {
            try
            {
                int occurrenceCount = _stringManipulatorService.CountOccurrences(input, character);
                return Ok(occurrenceCount);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/string/removeDuplicates")]
        public IActionResult RemoveDuplicates(string input)
        {
            try
            {
                string withoutDuplicates = _stringManipulatorService.RemoveDuplicates(input);
                return Ok(withoutDuplicates);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
