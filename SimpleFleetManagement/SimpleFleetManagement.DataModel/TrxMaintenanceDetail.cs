namespace SimpleFleetManagement.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrxMaintenanceDetail")]
    public partial class TrxMaintenanceDetail
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaintenanceId { get; set; }

        [Required]
        [StringLength(10)]
        public string MechanicId { get; set; }

        [Required]
        [StringLength(10)]
        public string ServiceId { get; set; }

        [Required]
        [StringLength(10)]
        public string PartId { get; set; }

        public int PartQuantity { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotalPrice { get; set; }

        public virtual MstCrew MstCrew { get; set; }

        public virtual MstPart MstPart { get; set; }

        public virtual MstService MstService { get; set; }

        public virtual TrxMaintenanceHeader TrxMaintenanceHeader { get; set; }
    }
}
