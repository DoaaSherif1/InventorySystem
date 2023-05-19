namespace EFFINAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MeasurementUnit
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Prod_Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Measurement_Unit { get; set; }

        public virtual Product Product { get; set; }
    }
}
