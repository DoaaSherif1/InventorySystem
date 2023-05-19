namespace EFFINAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Requests = new HashSet<Request>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Supplier_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Supplier_Name { get; set; }

        public int Telephone { get; set; }

        public int Mobile { get; set; }

        [Required]
        [StringLength(50)]
        public string Fax { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Website { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
