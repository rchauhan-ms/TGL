using Microsoft.AspNetCore.Components;
using Tgl.Shared.Domain;
using Tgl.Shared.Models;
using Tgl.UI.Services;

namespace Tgl.UI.Pages
{
    public partial class Index
    {
        [Inject]
        public IShipmentDataService ShipmentDataService { get; set; }

        [Inject]
        public IUserFilterDataService UserFilterDataService { get; set; }

        async Task ApplyFilterOnSummary(ShipmentFilterViewModel shipmentFilter)
        {
            UpdateUserFilterOnCheckbox(shipmentFilter);

            //save filters to json file
            var isFilterSaved = (await UserFilterDataService.SaveUserFilterAsync(shipmentFilter.UserFilter));

            //TODO: Filter the list of summaries based on the filters selected...
            ShipmentSummaries = (await ShipmentDataService.GetFilteredShipmentsAsync(shipmentFilter.UserFilter)).ToList();
        }

        private void UpdateUserFilterOnCheckbox(ShipmentFilterViewModel shipmentFilter)
        {
            foreach (var filter in shipmentFilter.CheckboxFilters)
            {
                if (filter.Value == "FromLocationComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.FromLocationSelected = Array.Empty<string>();
                }
                else if (filter.Value == "ToLocationComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.ToLocationSelected = Array.Empty<string>();
                }
                else if (filter.Value == "DeliveryDatePeriodComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.DeliveryPeriodSelected = new ();
                }
                else if (filter.Value == "ShipmentCostComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.ShipmentCostSelected = string.Empty;
                }
            }
        }

        public List<ShipmentSummary> ShipmentSummaries { get; set; } = new();
        private ShipmentFilterViewModel ShipmentFilterViewModel = new();
        public UserFilter UserFilter { get; set; } = new();
        protected async override Task OnInitializedAsync()
        {
            //Get UserFilters
            UserFilter = await UserFilterDataService.GetUserFilterAsync(); 

            ShipmentSummaries = (await ShipmentDataService.GetFilteredShipmentsAsync(UserFilter)).ToList();
            ShipmentFilterViewModel = MockDataService.ShipmentFilterViewModel(UserFilter);
        }
    }
}
