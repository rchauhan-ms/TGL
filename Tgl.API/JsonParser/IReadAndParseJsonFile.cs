using Tgl.Shared.Domain;

namespace Tgl.API.JsonParser
{
    public interface IReadAndParseJsonFile
    {
        Task<UserFilter> ReadJsonToObject();
        Task<bool> WriteObjectToJsonFile(UserFilter userFilter);
    }
}
