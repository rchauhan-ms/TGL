using Tgl.Shared.Domain;

namespace Tgl.Shared.Models
{
    public class ShipmentFilterViewModel
    {
        public Dictionary<string, string> Filters { get; set; }
        public List<CheckboxFilter> CheckboxFilters { get; set; } = new();
        public UserFilter UserFilter { get; set; }
    }

    public class CheckboxFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsFilterChecked { get; set; }
    }
}
