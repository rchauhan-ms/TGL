namespace Tgl.Shared.Domain
{
    public class UserFilter
    {
        public int[] FromLocationSelected { get; set; } = new int[] { };
        public int[] ToLocationSelected { get; set; } = new int[] { };
        public ShipmentCost ShipmentCostSelected { get; set; } = new();
        public DeliveryPeriod DeliveryPeriodSelected { get; set; } = new();
    }

}
