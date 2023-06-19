using Tgl.Shared.Domain;

namespace Tgl.Data.JsonParser
{
    public interface IReadAndParseJsonFile
    {
        Task<UserFilter> ReadJsonToObject();
        Task<bool> WriteObjectToJsonFile(UserFilter userFilter);
    }
}
