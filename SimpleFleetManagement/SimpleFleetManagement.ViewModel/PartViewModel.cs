using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class PartViewModel
    {
        public int Id { get; set; }

        [DisplayName("Part Code")]
        public string PartId { get; set; }

        [Required, DisplayName("Part Name")]
        public string Description { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Is Active ?")]
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
