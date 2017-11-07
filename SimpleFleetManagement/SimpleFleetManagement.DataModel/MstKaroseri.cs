namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MstKaroseri")]
    public partial class MstKaroseri
    {
        public MstKaroseri()
        {
            MstFleets = new HashSet<MstFleet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string KaroseriId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

        public virtual ICollection<MstFleet> MstFleets { get; set; }
    }
}
