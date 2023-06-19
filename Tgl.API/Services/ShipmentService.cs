using Tgl.Data.Repositories;
using Tgl.Shared.Domain;

namespace Tgl.API.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly ILogger _logger;

        public ShipmentService(IShipmentRepository shipmentRepository, ILogger<IUserFilterService> logger)
        {
            _shipmentRepository = shipmentRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<ShipmentSummary>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all Shipments");

            return await _shipmentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ShipmentSummary>> GetFilteredShipmentsAsync(UserFilter filter)
        {
            _logger.LogInformation("Retrieving all Shipments based on the User preferences");

            var summaries = await _shipmentRepository.GetAllAsync();

            //TODO: Filter logic needed to be tested properly
            var filteredSummaries = summaries.Where(x =>
                (filter.FromLocationSelected.Length == 0 || filter.FromLocationSelected.Contains(x.ShipmentFilter.FromLocation.Id)) &&
                (filter.ToLocationSelected.Length == 0 || filter.ToLocationSelected.Contains(x.ShipmentFilter.ToLocation.Id)) &&
                (filter.ShipmentCostSelected.Amount <= 0 || Helper.ShipmentCostComparisonFilter(filter.ShipmentCostSelected, x.ShippingCost))
            );

            return filteredSummaries.ToList();
        }
    }
}
