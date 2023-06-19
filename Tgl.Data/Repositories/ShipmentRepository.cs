using Tgl.Shared.Domain;

namespace Tgl.Data.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        public async Task<IEnumerable<ShipmentSummary>> GetAllAsync()
        {
            return await ShipmentDataStore.ShipmentSummaries();
        }
    }
}
