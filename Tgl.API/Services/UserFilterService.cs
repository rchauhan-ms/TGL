using Tgl.Data.Repositories;
using Tgl.Shared.Domain;

namespace Tgl.API.Services
{
    public class UserFilterService : IUserFilterService
    {
        private readonly IUserFilterRepository _userFilterRepository;
        private readonly ILogger _logger;
        public UserFilterService(IUserFilterRepository userFilterRepository, ILogger<IUserFilterService> logger)
        {
            _userFilterRepository = userFilterRepository;
            _logger = logger;
        }

        public async Task<UserFilter> GetUserFilterAsync()
        {
            return await _userFilterRepository.GetUserFilterAsync();
        }

        public async Task<bool> SaveUserFilterAsync(UserFilter userFilter)
        {
            return await _userFilterRepository.SaveUserFilterAsync(userFilter);
        }
    }
}
