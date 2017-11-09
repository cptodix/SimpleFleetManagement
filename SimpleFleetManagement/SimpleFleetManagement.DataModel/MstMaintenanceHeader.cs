namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MstMaintenanceHeader")]
    public partial class MstMaintenanceHeader
    {
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string MaintenanceId { get; set; }

        public DateTime MaintenanceDate { get; set; }

        [Required]
        [StringLength(10)]
        public string FleetId { get; set; }

        public int MaintenanceKm { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public virtual MstFleet MstFleet { get; set; }
    }
}
