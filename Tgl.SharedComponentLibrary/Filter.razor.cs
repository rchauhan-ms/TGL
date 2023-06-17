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

        //void AddToFromLocationSelected(string[] locationSelected) => ShipmentFilter.UserFilter.FromLocationSelected = locationSelected;

        //void AddToLocationSelected(string[] locationSelected)=> ShipmentFilter.UserFilter.ToLocationSelected = locationSelected;

        //void AddShipmentCostSelected(string shipmentCostSelected)=> ShipmentFilter.UserFilter.ShipmentCostSelected = shipmentCostSelected;

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

        void ApplyFilter()=> OnFilterSelected.InvokeAsync(ShipmentFilter.UserFilter);

        //private bool _isFromLocationChecked = false;
        //private bool _isToLocationChecked = false;
        //private bool _isDeliveryDatePeriodChecked = false;
        //private bool _isShipmentCostChecked = false;

        //private void CheckboxClickedAction(int key, object componentToLoad)
        //{

        //}
        //private void CheckboxClicked(string filterKey, object checkedValue)
        //{
        //    if (filterKey == ShipmentFilterConst.FROMLOCATION)
        //    {
        //        _isFromLocationChecked = (bool)checkedValue;
        //    }
        //    if (filterKey == ShipmentFilterConst.TOLOCATION)
        //    {
        //        _isToLocationChecked = (bool)checkedValue;
        //    }
        //    if (filterKey == ShipmentFilterConst.DELIVERYDATEPERIOD)
        //    {
        //        _isDeliveryDatePeriodChecked = (bool)checkedValue;
        //    }
        //    if (filterKey == ShipmentFilterConst.SHIPMENTCOST)
        //    {
        //        _isShipmentCostChecked = (bool)checkedValue;
        //    }
        //}
    }
}
