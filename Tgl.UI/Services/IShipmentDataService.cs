using Tgl.Shared.Domain;

namespace Tgl.UI.Services
{
    public interface IShipmentDataService
    {
        Task<IEnumerable<ShipmentSummary>> GetAllAsync();
        Task<IEnumerable<ShipmentSummary>> GetFilteredShipmentsAsync(UserFilter userFilter);
    }
}
