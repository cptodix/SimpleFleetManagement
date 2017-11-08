using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class FleetViewModel
    {
        public int Id { get; set; }

        public string FleetId { get; set; }

        [Required]
        public string TypeId { get; set; }

        public string TypeName { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        [Required]
        public string KaroseriId { get; set; }

        public string KaroseriName { get; set; }

        public int SeatCapacity { get; set; }
        
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }        
    }
}
