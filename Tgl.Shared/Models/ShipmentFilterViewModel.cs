using Tgl.Shared.Domain;

namespace Tgl.Shared.Models
{
    public class ShipmentFilterViewModel
    {
        public List<CheckboxFilter> CheckboxFilters { get; set; } = new();
        public UserFilter? UserFilter { get; set; }
    }
}
