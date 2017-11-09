namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MstPart")]
    public partial class MstPart
    {
        public MstPart()
        {
            TrxMaintenanceDetails = new HashSet<TrxMaintenanceDetail>();
            TrxMaintenanceDetails1 = new HashSet<TrxMaintenanceDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string PartId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

        public virtual ICollection<TrxMaintenanceDetail> TrxMaintenanceDetails { get; set; }

        public virtual ICollection<TrxMaintenanceDetail> TrxMaintenanceDetails1 { get; set; }
    }
}
