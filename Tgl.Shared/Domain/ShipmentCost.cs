using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgl.Shared.Domain
{
    public class ShipmentCost
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string? AmountText { get; set; }
    }
}
