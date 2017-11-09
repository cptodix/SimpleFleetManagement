using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class FleetViewModel
    {
        public int Id { get; set; }

        [DisplayName("Fleet Code")]
        public string FleetId { get; set; }

        public string MerkId { get; set; }

        public string MerkName { get; set; }

        [Required]
        public string TypeId { get; set; }

        public string TypeName { get; set; }

        [DisplayName("Fleet Brand Type")]
        public string BrandTypeName
        {
            get
            {
                return MerkName + " " + TypeName;
            }
        }

        [Required, DisplayName("License Plate")]
        public string LicenseNumber { get; set; }

        [Required]
        public string KaroseriId { get; set; }

        [DisplayName("Karoseri")]
        public string KaroseriName { get; set; }

        [DisplayName("Seat Capacity")]
        public int SeatCapacity { get; set; }
        
        [DisplayName("Is Active ?")]
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }        
    }
}
