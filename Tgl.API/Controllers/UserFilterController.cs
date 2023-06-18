using Microsoft.AspNetCore.Mvc;
using Tgl.API.Repositories;
using Tgl.Shared.Domain;

namespace Tgl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFilterController : ControllerBase
    {
        private readonly IUserFilterRepository _userFilterRepository;
        private readonly ILogger _logger;
        public UserFilterController(IUserFilterRepository userFilterRepository, ILogger<IUserFilterRepository> logger)
        {
            _userFilterRepository = userFilterRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserFilterAsync()
        {
            var filters = await _userFilterRepository.GetUserFilterAsync();
            if(filters is null)
                return NoContent();
            
            return Ok(filters);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveUserFilterAsync([FromBody] UserFilter filter)
        {
            if (filter == null)
                return BadRequest();

            var response = await _userFilterRepository.SaveUserFilterAsync(filter);
            return Ok(response);
        }
    }
}
