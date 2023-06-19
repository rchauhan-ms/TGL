using Tgl.Shared.Domain;

namespace Tgl.API
{
    internal static class Helper
    {
        internal static bool ShipmentCostComparisonFilter(ShipmentCost x, double y)
        {
            Func<double, double, bool> comparisonOperator = GetComparisonOperator(x.RelationalOperator);
            return comparisonOperator.Invoke(y, x.Amount);
        }

        // Helper method to convert string operator to a delegate
        private static Func<double, double, bool> GetComparisonOperator(string operatorString)
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
