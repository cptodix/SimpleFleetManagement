namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrxOrder")]
    public partial class TrxOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Destination { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TotalPerson { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderStatus { get; set; }
    }
}
