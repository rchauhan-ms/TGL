using Tgl.API.Data;
using Tgl.Shared.Domain;

namespace Tgl.API.Models
{
    public class ShipmentRepository : IShipmentRepository
    {
        public async Task<IEnumerable<ShipmentSummary>> GetAllAsync()
        {
            return await ShipmentDataStore.ShipmentSummaries();
        }

        public async Task<IEnumerable<ShipmentSummary>> GetFilteredShipmentsAsync(UserFilter filter)
        {
            //TODO: Implement rest of the filters..
            if (filter.FromLocationSelected.Length > 0)
            {
                return (await ShipmentDataStore.ShipmentSummaries())
                                    .Where(x => x.ShipmentFilter.FromLocation.Id == int.Parse(filter.FromLocationSelected[0]));
            }

            return await ShipmentDataStore.ShipmentSummaries();
        }
    }
}
