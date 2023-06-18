using Tgl.Shared.Domain;

namespace Tgl.Shared.Models
{
    public class MockDataService
    {
        public static ShipmentFilterViewModel ShipmentFilterViewModel(UserFilter filter = null)
        {
            var shipmentFilterViewModel = new ShipmentFilterViewModel();

            var checkboxFilters = new List<CheckboxFilter>()
            {
                { new CheckboxFilter { Id = 1, Name = "From Location", Value = "FromLocationComponent", IsFilterChecked = false } },
                { new CheckboxFilter { Id = 2, Name = "To Location", Value = "ToLocationComponent", IsFilterChecked = false } },
                { new CheckboxFilter { Id = 3, Name = "Delivery Date Period", Value = "DeliveryDatePeriodComponent", IsFilterChecked = false } },
                { new CheckboxFilter { Id = 4, Name = "Shipment Costs", Value = "ShipmentCostComponent", IsFilterChecked = false } },
            };
            
            if(filter != null) {
                if (filter.FromLocationSelected.Length > 0)
                {
                    checkboxFilters[0].IsFilterChecked = true;
                }
                if (filter.ToLocationSelected.Length > 0)
                {
                    checkboxFilters[1].IsFilterChecked = true;
                }
                if (filter.DeliveryPeriodSelected.StartDateText.Length > 0 || filter.DeliveryPeriodSelected.EndDateText.Length > 0)
                {
                    checkboxFilters[2].IsFilterChecked = true;
                }
                if (filter.ShipmentCostSelected.Amount > 0.00)
                {
                    checkboxFilters[3].IsFilterChecked = true;
                }
            }
            

            shipmentFilterViewModel.CheckboxFilters = checkboxFilters;

            shipmentFilterViewModel.UserFilter = filter?? new UserFilter();

            return shipmentFilterViewModel;
        }
        public static Dictionary<string, string> Filters
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    { "FromLocation", "From Location"},
                    { "ToLocation", "To Location"},
                    { "DeliveryDatePeriod", "Delivery Date Period"},
                    { "ShipmentCost", "Shipment Costs"},
                };
            }
        }

        //Mock data for Cities
        public static List<City> Cities
        {
            get
            {
                return new List<City>
                {
                    new City{ Id = 1, Name = "New York"},
                    new City{ Id = 2, Name = "LA"},
                    new City{ Id = 3, Name = "Shanghai"},
                    new City{ Id = 4, Name = "Sydney"},
                    new City{ Id = 5, Name = "Melbourne"},
                    new City{ Id = 6, Name = "Perth"},
                };
            }
        }

        //to location dropdown list
        public static List<City> FromLocationDropdownList
        {
            get
            {
                return MockDataService.Cities.Where(x => x.Id % 2 == 0).ToList();
            }
        }
        //to location dropdown list
        public static List<City> ToLocationDropdownList
        {
            get
            {
                return MockDataService.Cities.Where(x => x.Id % 2 != 0).ToList();
            }
        }
        //shipment cost dropdownlist
        public static List<ShipmentCost> ShipmentCostsDropdownList
        {
            get
            {
                return new List<ShipmentCost>()
                {
                    new ShipmentCost{ Id = 1, Amount = 2000.00, RelationalOperator = "<"},
                    new ShipmentCost{ Id = 2, Amount = 5000.00, RelationalOperator = "<"},
                    new ShipmentCost{ Id = 3, Amount = 10000.00 , RelationalOperator = "<"},
                    new ShipmentCost{ Id = 4, Amount = 10000.00, RelationalOperator = ">" }
                };
            }
        }
    }
}
