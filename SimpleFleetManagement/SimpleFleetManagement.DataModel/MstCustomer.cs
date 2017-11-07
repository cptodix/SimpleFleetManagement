namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MstCustomer")]
    public partial class MstCustomer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string OrganizationName { get; set; }

        [Required]
        [StringLength(300)]
        public string CustomerAddress { get; set; }

        [StringLength(300)]
        public string OrganizationAddress { get; set; }

        [Required]
        [StringLength(30)]
        public string IdNumber { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerPhone { get; set; }

        [StringLength(15)]
        public string OrganizationPhone { get; set; }

        [StringLength(50)]
        public string OrganizationEmail { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
