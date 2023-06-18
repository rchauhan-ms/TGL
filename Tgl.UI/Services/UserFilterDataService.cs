using System.Text;
using System.Text.Json;
using Tgl.Shared.Domain;

namespace Tgl.UI.Services
{
    public class UserFilterDataService : IUserFilterDataService
    {
        private readonly HttpClient _httpClient;
        public UserFilterDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserFilter> GetUserFilterAsync()
        {
            try
            {
                var userFilter = await JsonSerializer.DeserializeAsync<UserFilter>(
                await _httpClient.GetStreamAsync($"api/userfilter"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return userFilter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SaveUserFilterAsync(UserFilter userFilter)
        {
            var userFilterJson =
               new StringContent(JsonSerializer.Serialize(userFilter), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/userfilter", userFilterJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<bool>(await response.Content.ReadAsStreamAsync());
            }

            return false;
        }
    }
}
