using Tgl.Shared.Domain;

namespace Tgl.Shared.Models
{
    public class ShipmentFilterViewModel
    {
        public Dictionary<string, string> Filters { get; set; }
        public UserFilter UserFilter { get; set; }
    }
}
