using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class FleetOrderViewModel
    {
        public int Id { get; set; }

        [StringLength(10), DisplayName("Order")]
        public string OrderId { get; set; }

        [StringLength(10), DisplayName("Fleet")]
        public string FleetId { get; set; }

        public string FleetName { get; set; }

        [StringLength(10), DisplayName("Driver")]
        public string DriverId { get; set; }

        public string DriverName { get; set; }

        [StringLength(10), DisplayName("Assistant")]
        public string AssitantId { get; set; }

        public string AssitantName { get; set; }

        [DisplayName("Start Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DisplayName("Is Finished")]
        public bool IsFinished { get; set; }
    }

    public class FleetOrderException
    {
        public List<string> fleetexceptlist { get; set; }

        public List<string> driverexceptlist { get; set; }

        public List<string> assistantexceptlist { get; set; }

        public string startdate { get; set; }

        public string enddate { get; set; }
    }
}
