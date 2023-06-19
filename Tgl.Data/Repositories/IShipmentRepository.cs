using Tgl.Shared.Domain;

namespace Tgl.Data.Repositories
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<ShipmentSummary>> GetAllAsync();
    }
}
