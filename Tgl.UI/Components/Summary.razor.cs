using Microsoft.AspNetCore.Components;
using Tgl.Shared.Domain;

namespace Tgl.UI.Components
{
    public partial class Summary
    {
        [Parameter]
        public List<ShipmentSummary> ShipmentSummaries { get; set; }
    }
}
