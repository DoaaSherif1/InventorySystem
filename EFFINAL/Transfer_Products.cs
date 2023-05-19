namespace EFFINAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transfer_Products
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Prod_Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Source_Warehouse { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Destination_Warehouse { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Transfer_Id { get; set; }

        public int? Supplier_Id { get; set; }

        public int Prod_Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Production_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Validity_Period { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Transfer_Date { get; set; }

        public virtual Product Product { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Warehouse Warehouse1 { get; set; }
    }
}
