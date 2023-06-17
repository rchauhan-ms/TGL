using BlazorDateRangePicker;
using Microsoft.AspNetCore.Components;
using Tgl.Shared.Domain;
using Tgl.Shared.Models;

namespace Tgl.SharedComponentLibrary
{
    public partial class Filter
    {
        [Parameter]
        public ShipmentFilterViewModel? ShipmentFilter { get; set; }

        [Parameter]
        public EventCallback<UserFilter> OnFilterSelected { get; set; }

        public void OnRangeSelect(DateRange range)
        {
            if (range is not null)
            {
                ShipmentFilter.UserFilter.DeliveryPeriodSelected.StartDate = range.Start.DateTime;
                ShipmentFilter.UserFilter.DeliveryPeriodSelected.EndDate = range.End.DateTime;
                ShipmentFilter.UserFilter.DeliveryPeriodSelected.StartDateText = range.Start.Date.ToString("dd MMM yyyy");
                ShipmentFilter.UserFilter.DeliveryPeriodSelected.EndDateText = range.End.Date.ToString("dd MMM yyyy");
            }
        }


        //void HandleCheckedChanged(CheckboxFilter filter, ChangeEventArgs args)
        //{
        //    Console.WriteLine($"I am changed");
        //    this.ShipmentFilter.CheckboxFilters.RemoveAll(x => x.Id == filter.Id);
        //    this.ShipmentFilter.CheckboxFilters.Add(filter);
        //}

        void ApplyFilter()=> OnFilterSelected.InvokeAsync(ShipmentFilter.UserFilter);

    }
}
