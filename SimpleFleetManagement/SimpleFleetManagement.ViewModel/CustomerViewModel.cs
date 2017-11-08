using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }              
        
        public string CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public string OrganizationName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        public string OrganizationAddress { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public string CustomerPhone { get; set; }

        public string OrganizationPhone { get; set; }

        public string OrganizationEmail { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
