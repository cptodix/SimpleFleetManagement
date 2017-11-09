using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class KaroseriViewModel
    {
        public int Id { get; set; }

        [Required, DisplayName("Karoseri Code")]        
        public string KaroseriId { get; set; }

        [Required, DisplayName("Karoseri Name")]
        public string Description { get; set; }

        [DisplayName("Is Active ?")]
        public bool IsActive { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }
                
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
