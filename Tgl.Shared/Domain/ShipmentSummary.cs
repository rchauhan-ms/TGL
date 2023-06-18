namespace Tgl.Shared.Domain
{
    public class ShipmentSummary
    {
        public int ShippingId { get; set; }
        public string? ShippingCompany { get; set; }
        public string? ActionMessage { get; set; }
        public double ShippingCost { get; set; }
        public string[]? TrackingNumbers { get; set; }
        public Dictionary<string, DeliveryStatusEnum>? DeliveryStatuses { get; set; }
        public ShipmentFilter? ShipmentFilter { get; set; }
    }
}
