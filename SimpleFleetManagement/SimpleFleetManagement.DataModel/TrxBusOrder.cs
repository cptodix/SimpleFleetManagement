namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrxBusOrder")]
    public partial class TrxBusOrder
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(10)]
        public string FleetId { get; set; }

        [Required]
        [StringLength(10)]
        public string DriverId { get; set; }

        [Required]
        [StringLength(10)]
        public string AssitantId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsFinished { get; set; }
    }
}
