using Tgl.Shared.Domain;

namespace Tgl.API.Repositories
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<ShipmentSummary>> GetAllAsync();
        Task<IEnumerable<ShipmentSummary>> GetFilteredShipmentsAsync(UserFilter filter);
    }
}
