using Tgl.API.JsonParser;
using Tgl.Shared.Domain;

namespace Tgl.API.Models
{
    public class UserFilterRepository : IUserFilterRepository
    {
        private readonly IReadAndParseJsonFile _readAndParseJsonFile;
        public UserFilterRepository(IReadAndParseJsonFile readAndParseJsonFile)
        {
            _readAndParseJsonFile = readAndParseJsonFile;
        }
        public async Task<UserFilter> GetUserFilterAsync()
        {
            return await _readAndParseJsonFile.ReadJsonToObject();
        }

        public async Task<bool> SaveUserFilterAsync(UserFilter userFilter)
        {
            var isFileSaved = await _readAndParseJsonFile.WriteObjectToJsonFile(userFilter);
            return isFileSaved;
        }
    }
}
