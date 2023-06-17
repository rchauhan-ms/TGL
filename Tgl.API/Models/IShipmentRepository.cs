using Tgl.Shared.Domain;

namespace Tgl.API.Models
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<ShipmentSummary>> GetAllAsync();
        Task<IEnumerable<ShipmentSummary>> GetFilteredShipmentsAsync(UserFilter filter);
    }
}
