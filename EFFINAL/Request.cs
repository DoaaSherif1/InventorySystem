namespace EFFINAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Prod_Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Warehouse_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Supplier_Id { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Req_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Req_Date { get; set; }

        public int Prod_Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Production_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Validity_Period { get; set; }

        [StringLength(50)]
        public string Req_Type { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
