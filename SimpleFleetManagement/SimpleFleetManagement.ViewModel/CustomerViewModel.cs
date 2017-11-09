using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFleetManagement.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Customer Code")]
        public string CustomerId { get; set; }

        [Required, DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; }

        [Required, DisplayName("Customer Address")]
        public string CustomerAddress { get; set; }

        [DisplayName("Organization Address")]
        public string OrganizationAddress { get; set; }

        [Required, DisplayName("Id Number")]
        public string IdNumber { get; set; }

        [Required, DisplayName("Customer Phone")]
        public string CustomerPhone { get; set; }

        [DisplayName("Organization Phone")]
        public string OrganizationPhone { get; set; }

        [DisplayName("Organization Email")]
        public string OrganizationEmail { get; set; }

        [DisplayName("Is Active ?")]
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
