using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class MerkBusViewModel
    {
        public int Id { get; set; }

        [Required]
        public string MerkId { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsActive { get; set; }
                
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }
                
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

    }
}
