using Microsoft.AspNetCore.Components;
using Tgl.Shared.Domain;

namespace Tgl.UI.Shared
{
    public partial class Summary
    {
        [Parameter]
        public List<ShipmentSummary> ShipmentSummaries { get; set; }
    }
}
