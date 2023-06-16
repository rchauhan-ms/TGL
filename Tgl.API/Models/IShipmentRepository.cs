using Tgl.Shared.Domain;

namespace Tgl.API.Models
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<ShipmentSummary>> GetAll();
        Task<IEnumerable<ShipmentSummary>> GetFilteredShipments(UserFilter filter);
    }
}
