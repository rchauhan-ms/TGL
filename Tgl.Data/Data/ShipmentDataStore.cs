using Tgl.Shared.Domain;

namespace Tgl.Data
{
    public class ShipmentDataStore
    {
        public static Task<List<ShipmentSummary>> ShipmentSummaries()
        {
            var shipmentSummaries = new List<ShipmentSummary>()
                {
                    new ShipmentSummary()
                    {
                        ShippingId = 2015149,
                        ActionMessage = "PENDING DELIVERY",
                        DeliveryStatuses = new Dictionary<string, DeliveryStatusEnum>()
                        {
                            { "REGISTERED", DeliveryStatusEnum.Completed },
                            { "AT ORIGIN", DeliveryStatusEnum.Completed },
                            { "IN TRANSIT", DeliveryStatusEnum.Completed },
                            { "ARRIVAL", DeliveryStatusEnum.Current },
                            { "DELIVERY", DeliveryStatusEnum.Pending }
                        },
                        ShippingCompany = "SATECHI CO LTD",
                        TrackingNumbers = new []{ "POAU000657" },
                        ShipmentFilter = new ShipmentFilter()
                        {
                             FromLocation = new City{ Id = 4, Name = "Sydney"},
                             ToLocation = new City{ Id = 3, Name = "Shanghai"},
                             FromDate = "31 Mar 2023",
                             ToDate = "14 May 2023"
                        },
                        ShippingCost = 2000.00
                    },
                    new ShipmentSummary()
                    {
                        ShippingId = 2015145,
                        ActionMessage = "PENDING DELIVERY",
                        DeliveryStatuses = new Dictionary<string, DeliveryStatusEnum>()
                        {
                            { "REGISTERED", DeliveryStatusEnum.Completed },
                            { "AT ORIGIN", DeliveryStatusEnum.Completed },
                            { "IN TRANSIT", DeliveryStatusEnum.Current },
                            { "ARRIVAL", DeliveryStatusEnum.Pending },
                            { "DELIVERY", DeliveryStatusEnum.Pending }
                        },
                        ShippingCompany = "SATECHI CO LTD",
                        TrackingNumbers = new []{ "POAU000657" },
                        ShipmentFilter = new ShipmentFilter()
                        {
                             FromLocation = new City{ Id = 4, Name = "Sydney"},
                             ToLocation = new City{ Id = 5, Name = "Melbourne"},
                             FromDate = "01 Jan 2023",
                             ToDate = "14 Feb 2023"
                        },
                        ShippingCost = 4000.00
                    },
                    new ShipmentSummary()
                    {
                        ShippingId = 2388758,
                        ActionMessage = "PENDING DELIVERY",
                        DeliveryStatuses = new Dictionary<string, DeliveryStatusEnum>()
                        {
                            { "REGISTERED", DeliveryStatusEnum.Completed },
                            { "AT ORIGIN", DeliveryStatusEnum.Completed },
                            { "IN TRANSIT", DeliveryStatusEnum.Completed },
                            { "ARRIVAL", DeliveryStatusEnum.Current },
                            { "DELIVERY", DeliveryStatusEnum.Pending }
                        },
                        ShippingCompany = "SATECHI CO LTD",
                        TrackingNumbers = new []{ "POAU000657" },
                        ShipmentFilter = new ShipmentFilter()
                        {
                             FromLocation = new City{ Id = 2, Name = "LA"},
                             ToLocation = new City{ Id = 1, Name = "New York"},
                             FromDate = "16 Feb 2023",
                             ToDate = "24 Oct 2023"
                        },
                        ShippingCost = 12000.00
                    },
                    new ShipmentSummary()
                    {
                        ShippingId = 5946886,
                        ActionMessage = "PENDING DELIVERY",
                        DeliveryStatuses = new Dictionary<string, DeliveryStatusEnum>()
                        {
                            { "REGISTERED", DeliveryStatusEnum.Completed },
                            { "AT ORIGIN", DeliveryStatusEnum.Completed },
                            { "IN TRANSIT", DeliveryStatusEnum.Completed },
                            { "ARRIVAL", DeliveryStatusEnum.Completed },
                            { "DELIVERY", DeliveryStatusEnum.Completed }
                        },
                        ShippingCompany = "SATECHI CO LTD",
                        TrackingNumbers = new []{ "POAU000657" },
                        ShipmentFilter = new ShipmentFilter()
                        {
                             FromLocation = new City{ Id = 2, Name = "LA"},
                             ToLocation = new City{ Id = 3, Name = "Melbourne"},
                             FromDate = "01 Aug 2023",
                             ToDate = "01 Dec 2023"
                        },
                        ShippingCost = 8000.00
                    },
                    new ShipmentSummary()
                    {
                        ShippingId = 3498575,
                        ActionMessage = "PENDING DELIVERY",
                        DeliveryStatuses = new Dictionary<string, DeliveryStatusEnum>()
                        {
                            { "REGISTERED", DeliveryStatusEnum.Completed },
                            { "AT ORIGIN", DeliveryStatusEnum.Completed },
                            { "IN TRANSIT", DeliveryStatusEnum.Current },
                            { "ARRIVAL", DeliveryStatusEnum.Pending },
                            { "DELIVERY", DeliveryStatusEnum.Pending }
                        },
                        ShippingCompany = "SATECHI CO LTD",
                        TrackingNumbers = new []{ "POAU000657" },
                        ShipmentFilter = new ShipmentFilter()
                        {
                             FromLocation = new City{ Id = 4, Name = "Sydney"},
                             ToLocation = new City{ Id = 3, Name = "New York"},
                             FromDate = "18 Mar 2023",
                             ToDate = "30 Apr 2023"
                        },
                        ShippingCost = 5000.00
                    },
                };
            return Task.FromResult(shipmentSummaries);
        }
    }
}
