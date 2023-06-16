using System.Text;
using System.Text.Json;
using Tgl.Shared.Domain;

namespace Tgl.UI.Services
{
    public class ShipmentDataService : IShipmentDataService
    {
        private readonly HttpClient _httpClient;

        public ShipmentDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ShipmentSummary>> GetAll()
        {
            var shipmentSummaries = await JsonSerializer.DeserializeAsync<IEnumerable<ShipmentSummary>>(
                await _httpClient.GetStreamAsync($"api/shipment"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );

            return shipmentSummaries!;
        }

        public async Task<IEnumerable<ShipmentSummary>> GetFilteredShipments(UserFilter userFilter)
        {
            IEnumerable<ShipmentSummary>? shipmentSummary = null;

            var userFilterJson =
                new StringContent(JsonSerializer.Serialize(userFilter), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/shipment", userFilterJson);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStreamAsync();
                shipmentSummary = await JsonSerializer.DeserializeAsync<IEnumerable<ShipmentSummary>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return shipmentSummary!;
        }
    }
}
