using Microsoft.AspNetCore.Mvc;
using QuantityMeasurement.Business.Interfaces;
using QuantityMeasurement.Model.DTO;

namespace QuantityMeasurement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuantityMeasurementController : ControllerBase
    {
        private readonly IQuantityAppService _service;

        public QuantityMeasurementController(IQuantityAppService service)
        {
            _service = service;
        }

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] QuantityInputDTO input)
        {
            var result = _service.Compare(input.ThisQuantityDTO, input.ThatQuantityDTO);
            return Ok(result);
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] QuantityDTO input, [FromQuery] string targetUnit)
        {
            var result = _service.Convert(input, targetUnit);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] QuantityInputDTO input, [FromQuery] string targetUnit)
        {
            var result = _service.Add(input.ThisQuantityDTO, input.ThatQuantityDTO, targetUnit);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] QuantityInputDTO input, [FromQuery] string targetUnit)
        {
            var result = _service.Subtract(input.ThisQuantityDTO, input.ThatQuantityDTO, targetUnit);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] QuantityInputDTO input)
        {
            var result = _service.Divide(input.ThisQuantityDTO, input.ThatQuantityDTO);
            return Ok(result);
        }
    }
}