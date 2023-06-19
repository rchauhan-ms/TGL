using Microsoft.AspNetCore.Mvc;
using Tgl.API.Services;
using Tgl.Data.Repositories;
using Tgl.Shared.Domain;

namespace Tgl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFilterController : ControllerBase
    {
        private readonly IUserFilterService _userFilterService;
        private readonly ILogger _logger;
        public UserFilterController(IUserFilterService userFilterService, ILogger<IUserFilterRepository> logger)
        {
            _userFilterService = userFilterService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserFilterAsync()
        {
            try
            {
                var filters = await _userFilterService.GetUserFilterAsync();
                if (filters is null)
                    return NoContent();

                return Ok(filters);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            finally
            {
                _logger.Log(LogLevel.Information, "Provided the list of user prefrences");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveUserFilterAsync([FromBody] UserFilter filter)
        {
            if (filter == null)
                return BadRequest();

            var response = await _userFilterService.SaveUserFilterAsync(filter);
            return Ok(response);
        }
    }
}
