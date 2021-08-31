using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
      
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber,string secondNumber)
        {
            if (IsNumber(firstNumber) && IsNumber(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Entrada invalida");
        } 
        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber,string secondNumber)
        {
            if (IsNumber(firstNumber) && IsNumber(secondNumber)) {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Entrada invalida");
        }
         [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber,string secondNumber)
        {
            if (IsNumber(firstNumber) && IsNumber(secondNumber)) {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Entrada invalida");
        }
          [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult(string firstNumber,string secondNumber)
        {
            if (IsNumber(firstNumber) && IsNumber(secondNumber)) {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Entrada invalida");
        }

        private bool IsNumber(string strNumber) {

            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,out number);
            return isNumber;        
        } 
        private decimal ConvertToDecimal(string number) {
            decimal valorDecimal;
            if (decimal.TryParse(number, out valorDecimal))
                return valorDecimal;

            return 0;
        }
    }
}
