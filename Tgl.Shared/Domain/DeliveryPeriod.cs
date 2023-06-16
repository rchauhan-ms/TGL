using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgl.Shared.Domain
{
    public class DeliveryPeriod
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateText { get; set; } = string.Empty;
        public string EndDateText { get; set; } = string.Empty;
    }
}
