using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class CrewViewModel
    {
        public int Id { get; set; }
                
        public string CrewId { get; set; }

        [Required]        
        public string CrewName { get; set; }

        [Required]        
        public string DrivingLicenseNumber { get; set; }

        [Required]        
        public string Address { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]        
        public string Gender { get; set; }

        [Required]
        public string Role { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }
                
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
