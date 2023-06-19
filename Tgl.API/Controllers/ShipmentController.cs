using Microsoft.AspNetCore.Mvc;
using Tgl.API.Services;
using Tgl.Shared.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tgl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;
        private readonly ILogger<ShipmentController> _logger;
        public ShipmentController(IShipmentService shipmentService, ILogger<ShipmentController> logger)
        {
            _shipmentService = shipmentService;
            _logger = logger;
        }

        [HttpGet(Name = "allshipments")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var shipments = await _shipmentService.GetAllAsync();
            if (shipments is null)
                return NoContent();

            return Ok(shipments);
        }

        [HttpPost(Name = "filteredshipments")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilteredShipmentsAsync([FromBody] UserFilter filter)
        {
            if (filter == null)
                return BadRequest();

            var shipments = await _shipmentService.GetFilteredShipmentsAsync(filter);
            return Ok(shipments);
        }
    }
}
