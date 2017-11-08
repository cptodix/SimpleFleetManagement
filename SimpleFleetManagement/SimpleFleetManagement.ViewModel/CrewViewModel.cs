using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayFormat(DataFormatString="{0:dd MMM yyyy}",ApplyFormatInEditMode=true)]
        public DateTime DateOfBirth { get; set; }

        [Required]        
        public string Gender { get; set; }

        [DisplayName("Gender Name")]
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case "M":
                        return "Male";
                    case "F":
                        return "Female";
                    default:
                        return "";
                }
            }
        }

        [Required]
        public string Role { get; set; }

        [DisplayName("Role Name")]
        public string RoleName
        {
            get
            {
                switch (Role)
                {
                    case "D":
                        return "Driver";
                    case "A":
                        return "Assistant";
                    case "M":
                        return "Mechanic";
                    default:
                        return "";
                }
            }
        }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }
                
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
