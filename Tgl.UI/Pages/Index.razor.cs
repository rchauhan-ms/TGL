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

            var isFilterSaved = (await UserFilterDataService.SaveUserFilterAsync(shipmentFilter.UserFilter));

            ShipmentSummaries = (await ShipmentDataService.GetFilteredShipmentsAsync(shipmentFilter.UserFilter))
                                .ToList();
        }

        private void UpdateUserFilterOnCheckbox(ShipmentFilterViewModel shipmentFilter)
        {
            foreach (var filter in shipmentFilter.CheckboxFilters)
            {
                if (filter.Value == "FromLocationComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.FromLocationSelected = new int[] { };
                }
                else if (filter.Value == "ToLocationComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.ToLocationSelected = new int[] { };
                }
                else if (filter.Value == "DeliveryDatePeriodComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.DeliveryPeriodSelected = new ();
                }
                else if (filter.Value == "ShipmentCostComponent" && !filter.IsFilterChecked)
                {
                    shipmentFilter.UserFilter.ShipmentCostSelected.Amount = 0;
                }
            }
        }
        private List<ShipmentSummary> ShipmentSummaries { get; set; } = new();
        private ShipmentFilterViewModel ShipmentFilterViewModel { get; set; } = new();
        private UserFilter UserFilter { get; set; } = new();
        protected async override Task OnInitializedAsync()
        {
            //Get UserFilters
            UserFilter = await UserFilterDataService.GetUserFilterAsync();
            
            ShipmentSummaries = UserFilter == null ? (await ShipmentDataService.GetAllAsync()).ToList() :
                (await ShipmentDataService.GetFilteredShipmentsAsync(UserFilter)).ToList();

            ShipmentFilterViewModel = MockDataService.ShipmentFilterViewModel(UserFilter);
        }
    }
}
