using BlazorDateRangePicker;
using Microsoft.AspNetCore.Components;
using Tgl.Shared.Models;

namespace Tgl.SharedComponentLibrary
{
    public partial class Filter
    {
        [Parameter]
        public ShipmentFilterViewModel? ShipmentFilterViewModel { get; set; } = new();

        [Parameter]
        public EventCallback<ShipmentFilterViewModel> OnFilterSelected { get; set; }

        public void OnRangeSelect(DateRange range)
        {
            if (range != null)
            {
                var deliveryPeriodSelected = ShipmentFilterViewModel.UserFilter.DeliveryPeriodSelected;
                var startDateTime = range.Start.DateTime;
                var endDateTime = range.End.DateTime;

                deliveryPeriodSelected.StartDate = startDateTime;
                deliveryPeriodSelected.EndDate = endDateTime;
                deliveryPeriodSelected.StartDateText = range.Start.Date.ToString("dd MMM yyyy");
                deliveryPeriodSelected.EndDateText = range.End.Date.ToString("dd MMM yyyy");
            }
        }
        
        void ApplyFilter()=> OnFilterSelected.InvokeAsync(ShipmentFilterViewModel);
    }
}
