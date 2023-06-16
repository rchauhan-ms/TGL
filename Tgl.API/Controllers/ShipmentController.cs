using Microsoft.AspNetCore.Mvc;
using Tgl.API.Models;
using Tgl.Shared.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tgl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : Controller
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentController(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shipments = await _shipmentRepository.GetAll();
            return Ok(shipments);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFilteredShipments([FromBody] UserFilter filter)
        {
            if (filter == null)
                return BadRequest();

            var shipments = await _shipmentRepository.GetFilteredShipments(filter);
            return Ok(shipments);
        }
    }
}
