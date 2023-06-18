using Microsoft.AspNetCore.Components;
using Tgl.Shared.Domain;
using Tgl.Shared.Models;

namespace Tgl.SharedComponentLibrary
{
    public partial class ShipmentCostMultiSelect
    {
        [Parameter]
        public EventCallback<ShipmentCost> OnShipmentCostSelection { get; set; }

        [Parameter]
        public int SelectedShipmentCostId { get; set; }

        protected async Task OnShipmentCostSelectChange(ChangeEventArgs args)
        {
            SelectedShipmentCostId = int.Parse((string?)args.Value);
            var selectedShipmentCost = MockDataService.ShipmentCostsDropdownList
                                        .Where(x => x.Id == SelectedShipmentCostId)
                                        .FirstOrDefault();
            
            await OnShipmentCostSelection.InvokeAsync(selectedShipmentCost);
        }
    }
}
