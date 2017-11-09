using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class MerkBusViewModel
    {
        public int Id { get; set; }

        [Required, DisplayName("Brand Code")]
        public string MerkId { get; set; }

        [Required, DisplayName("Brand Name")]
        public string Description { get; set; }

        [DisplayName("Is Active ?")]
        public bool IsActive { get; set; }
                
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }
                
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

    }
}
