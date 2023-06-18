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

            
            //If filter.ToLocationSelected or filter.FromLocationSelected or filter.ShipmentCostSelected empty then 
            //consider loading everything corresponding to each else apply filter
            var result = summaries.Where(x => filter.FromLocationSelected.Contains(x.ShipmentFilter.FromLocation.Id)
                                   && filter.ToLocationSelected.Contains(x.ShipmentFilter.ToLocation.Id)
                                   && ShipmentCostComparisonFilter(filter.ShipmentCostSelected, x.ShippingCost))
                                  .ToList();

            return result;
        }

        public static bool ShipmentCostComparisonFilter(ShipmentCost x, double y)
        {
            Func<double, double, bool> comparisonOperator = GetComparisonOperator(x.RelationalOperator);
            return comparisonOperator.Invoke(y, x.Amount);
        }

        // Helper method to convert string operator to a delegate
        public static Func<double,double,bool> GetComparisonOperator(string operatorString)
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
