namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MstService")]
    public partial class MstService
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string ServiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
