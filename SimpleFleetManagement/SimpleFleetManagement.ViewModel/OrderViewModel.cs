using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Order Code")]
        public string OrderId { get; set; }

        public string CustomerId { get; set; }

        [DisplayName("Customer")]
        public string CustomerName { get; set; }

        [DisplayName("Order Name")]
        public string OrderName { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Destinations")]
        public string Destination { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("Finish Date")]
        public DateTime EndDate { get; set; }

        [DisplayName("Persons")]
        public int TotalPerson { get; set; }

        public string OrderStatus { get; set; }

        [DisplayName("Order Status")]
        public string OrderStatusName
        {
            get
            {
                switch(OrderStatus)
                {
                    case "B":
                        return "Booked";
                    case "O":
                        return "Ongoing";
                    case "D":
                        return "Done";
                    default:
                        return "";
                }
            }
        }

        public List<FleetOrderViewModel> BusOrder { get; set; }
    }
}
