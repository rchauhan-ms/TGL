using Tgl.Shared.Domain;

namespace Tgl.API.Services
{
    public interface IShipmentService
    {
        Task<IEnumerable<ShipmentSummary>> GetAllAsync();
        Task<IEnumerable<ShipmentSummary>> GetFilteredShipmentsAsync(UserFilter userFilter);
    }
}
