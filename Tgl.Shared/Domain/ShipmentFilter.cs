namespace Tgl.Shared.Domain
{
    public class ShipmentFilter
    {
        public City? FromLocation { get; set; }
        public City? ToLocation { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public ShipmentCost? ShipmentCost { get; set; }
    }
}
