using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tgl.API.Models;
using Tgl.Shared.Domain;

namespace Tgl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFilterController : ControllerBase
    {
        private readonly IUserFilterRepository _userFilterRepository;
        public UserFilterController(IUserFilterRepository userFilterRepository)
        {
            _userFilterRepository = userFilterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFilterAsync()
        {
            var filters = await _userFilterRepository.GetUserFilterAsync();
            return Ok(filters);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserFilterAsync([FromBody] UserFilter filter)
        {
            var response = await _userFilterRepository.SaveUserFilterAsync(filter);
            return Ok(response);
        }
    }
}
