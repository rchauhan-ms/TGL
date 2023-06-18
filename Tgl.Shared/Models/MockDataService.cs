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

            SetCheckboxFilters(filter, checkboxFilters);

            shipmentFilterViewModel.CheckboxFilters = checkboxFilters;
            shipmentFilterViewModel.UserFilter = filter?? new UserFilter();

            return shipmentFilterViewModel;
        }

        public static List<City> LocationDropdownList
        {
            get
            {
                return new List<City>
                {
                    new City{ Id = 1, Name = "New York", BindTo="To"},
                    new City{ Id = 2, Name = "LA", BindTo="From"},
                    new City{ Id = 3, Name = "Shanghai", BindTo="To"},
                    new City{ Id = 4, Name = "Sydney", BindTo="From"},
                    new City{ Id = 5, Name = "Melbourne", BindTo="To"},
                    new City{ Id = 6, Name = "Perth", BindTo="From"},
                };
            }
        }

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

        private static void SetCheckboxFilters(UserFilter filter, List<CheckboxFilter> checkboxFilters)
        {
            if (filter != null)
            {
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
        }
    }
}
