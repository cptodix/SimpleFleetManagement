using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class MaintenanceDetailViewModel
    {
        public int Id { get; set; }
        public string MaintenanceId { get; set; }
        public string MechanicId { get; set; }
        public string ServiceId { get; set; }
        public string PartId { get; set; }
        public int PartQuantity { get; set; }
        public decimal SubTotalPrice { get; set; }
    }
}
