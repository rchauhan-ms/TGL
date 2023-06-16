using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgl.Shared.Domain
{
    public class UserFilter
    {
        public string[] FromLocationSelected { get; set; } = new string[] { };
        public string[] ToLocationSelected { get; set; } = new string[] { };
        public string ShipmentCostSelected { get; set; } = string.Empty;
        public DeliveryPeriod DeliveryPeriodSelected { get; set; } = new();
    }
}
