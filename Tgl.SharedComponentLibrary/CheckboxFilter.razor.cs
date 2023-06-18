using Microsoft.AspNetCore.Components;
using Tgl.Shared.Domain;
using Tgl.Shared.Models;

namespace Tgl.SharedComponentLibrary
{
    public partial class CheckboxFilter
    {
        [Parameter]
        public ShipmentFilterViewModel? ShipmentFilterViewModel { get; set; } = new();

        [Parameter]
        public EventCallback<ShipmentFilterViewModel> OnFilterSelected { get; set; }

        protected void AddShipmentCostSelected(ShipmentCost shipmentCost)
        {
            ShipmentFilterViewModel.UserFilter.ShipmentCostSelected = shipmentCost;
        }

        protected void AddDeliveryPeriodSelected(DeliveryPeriod deliveryPeriod)
        {
            ShipmentFilterViewModel.UserFilter.DeliveryPeriodSelected = deliveryPeriod;
        }

        void ApplyFilter()=> OnFilterSelected.InvokeAsync(ShipmentFilterViewModel);
    }
}
