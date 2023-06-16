using Microsoft.AspNetCore.Components;

namespace Tgl.SharedComponentLibrary
{
    public partial class ShipmentCostMultiSelect
    {
        [Parameter]
        public EventCallback<string> OnShipmentCostSelected { get; set; }

        void OnShipmentCostSelect(ChangeEventArgs args)
        {
            OnShipmentCostSelected.InvokeAsync((string?)args.Value);
        }
    }
}
