using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tgl.Shared.Domain;

namespace Tgl.Data.JsonParser
{
    public class ReadAndParseJsonFile : IReadAndParseJsonFile
    {
        private readonly string _jsonFilePath = @"wwwroot\userfilter.json";
        private readonly ILogger _logger;

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public ReadAndParseJsonFile(ILogger<IReadAndParseJsonFile> logger)
        {
            _logger = logger;
        }

        public async Task<UserFilter> ReadJsonToObject()
        {
            using FileStream json = File.OpenRead(_jsonFilePath);
            var userFilter = await JsonSerializer.DeserializeAsync<UserFilter>(json, _options);

            return userFilter;
        }

        public Task<bool> WriteObjectToJsonFile(UserFilter userFilter)
        {
            bool isDataSaved = false;
            try
            {
                var jsonString = JsonSerializer.Serialize(userFilter, _options);
                File.WriteAllText(_jsonFilePath, jsonString);
                isDataSaved = true;
            }
            catch (Exception ex)
            {
                isDataSaved = false;
            }
            return Task.FromResult(isDataSaved);
        }
    }
}
