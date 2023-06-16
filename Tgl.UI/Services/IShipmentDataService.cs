using Tgl.Shared.Domain;

namespace Tgl.UI.Services
{
    public interface IShipmentDataService
    {
        Task<IEnumerable<ShipmentSummary>> GetAll();
        Task<IEnumerable<ShipmentSummary>> GetFilteredShipments(UserFilter userFilter);
    }
}
