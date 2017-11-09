using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class MaintenanceHeaderViewModel
    {
        public int Id { get; set; }
        public string MaintenanceId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string FleetId { get; set; }
        public int MaintenanceKm { get; set; }
        public decimal TotalPrice { get; set; }
        public List<MaintenanceDetailViewModel> MaintenanceDetails { get; set; }
    }
}
