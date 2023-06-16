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

        async Task ApplyFilterOnSummary(UserFilter userFilter)
        {
            //save filters to json file
            var isFilterSaved = (await UserFilterDataService.SaveUserFilterAsync(userFilter));

            //TODO: Filter the list of summaries based on the filters selected...
            var filteredShipments = (await ShipmentDataService.GetFilteredShipments(userFilter)).ToList();
            ShipmentSummaries = filteredShipments;
        }

        public List<ShipmentSummary> ShipmentSummaries { get; set; } = new();
        private ShipmentFilterViewModel ShipmentFilterViewModel = new();
        public UserFilter UserFilter { get; set; } = new();
        protected async override Task OnInitializedAsync()
        {
            //Get UserFilters
            UserFilter = await UserFilterDataService.GetUserFilterAsync(); 

            ShipmentSummaries = (await ShipmentDataService.GetFilteredShipments(UserFilter)).ToList();
            ShipmentFilterViewModel = MockDataService.ShipmentFilterViewModel(UserFilter);
        }
    }
}
