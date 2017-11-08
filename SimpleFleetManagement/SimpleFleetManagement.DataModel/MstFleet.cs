namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MstFleet")]
    public partial class MstFleet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string FleetId { get; set; }

        [Required]
        [StringLength(10)]
        public string TypeId { get; set; }

        [Required]
        [StringLength(15)]
        public string LicenseNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string KaroseriId { get; set; }

        public int SeatCapacity { get; set; }
        
        public bool IsActive { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

        public virtual MstKaroseri MstKaroseri { get; set; }

        public virtual MstTypeBu MstTypeBu { get; set; }
    }
}
