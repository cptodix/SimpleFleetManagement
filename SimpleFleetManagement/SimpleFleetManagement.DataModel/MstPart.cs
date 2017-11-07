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
    }
}
