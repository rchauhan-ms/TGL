using System.Reflection.Metadata.Ecma335;
using Tgl.API.Data;
using Tgl.Shared.Domain;

namespace Tgl.API.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        public async Task<IEnumerable<ShipmentSummary>> GetAllAsync()
        {
            return await ShipmentDataStore.ShipmentSummaries();
        }

        public async Task<IEnumerable<ShipmentSummary>> GetFilteredShipmentsAsync(UserFilter filter)
        {
            var summaries = await ShipmentDataStore.ShipmentSummaries();

            var filteredSummaries = summaries.Where(x =>
                (filter.FromLocationSelected.Length == 0 || filter.FromLocationSelected.Contains(x.ShipmentFilter.FromLocation.Id)) &&
                (filter.ToLocationSelected.Length == 0 || filter.ToLocationSelected.Contains(x.ShipmentFilter.ToLocation.Id)) &&
                (filter.ShipmentCostSelected.Amount <= 0 || ShipmentCostComparisonFilter(filter.ShipmentCostSelected, x.ShippingCost))
            );

            return filteredSummaries.ToList();
        }

        public static bool ShipmentCostComparisonFilter(ShipmentCost x, double y)
        {
            Func<double, double, bool> comparisonOperator = GetComparisonOperator(x.RelationalOperator);
            return comparisonOperator.Invoke(y, x.Amount);
        }

        // Helper method to convert string operator to a delegate
        public static Func<double, double, bool> GetComparisonOperator(string operatorString)
        {
            switch (operatorString)
            {
                case "<":
                    return (a, b) => a < b;
                case ">":
                    return (a, b) => a > b;
                default:
                    throw new ArgumentException("Invalid operator string.");
            }
        }
    }
}
