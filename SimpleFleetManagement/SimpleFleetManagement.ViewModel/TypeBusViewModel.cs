using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class TypeBusViewModel
    {
        public int Id { get; set; }
        [Required]
        public string MerkId { get; set; }
        [Required, DisplayName("Brand Type Code")]
        public string TypeId { get; set; }
        [DisplayName("Brand")]
        public string MerkName { get; set; }
        [Required, DisplayName("Brand Type Name")]
        public string Description { get; set; }

        [DisplayName("Is Active ?")]
        public bool IsActive { get; set; }
                
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }
                
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
